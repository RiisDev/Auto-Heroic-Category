using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroicCategory.Misc
{
    public class ProgressBar : IDisposable
    {
        internal bool failedStatus = false;
        private const int BlockCount = 50;
        private readonly TimeSpan _animationInterval = TimeSpan.FromSeconds(1.0 / 8);
        private const string Animation = @"|/-\";

        private readonly Timer _timer;
        private readonly object _lock = new();

        private double _currentProgress;
        private string _currentText = string.Empty;
        private bool _disposed;
        private int _animationIndex;

        private int f = 0;
        private int r = 0;

        public ProgressBar()
        {
            _timer = new Timer(TimerHandler);

            if (!Console.IsOutputRedirected)
            {
                ResetTimer();
            }
        }

        public void Report(int i, int d)
        {
            f = i;
            r = d;
            double value = (i + .0) / (d + .0);
            Interlocked.Exchange(ref _currentProgress, Math.Max(0, Math.Min(1, value)));
        }

        private void TimerHandler(object state)
        {
            lock (_lock)
            {
                if (_disposed) return;

                ConsoleColor oldColor = Console.ForegroundColor;

                int progressBlockCount = (int)(_currentProgress * BlockCount);
                int percent = (int)(_currentProgress * 100);
                string text = $"[{new string('\u2588', progressBlockCount)}{new string('-', BlockCount - progressBlockCount)}] {percent,3}% ({f}/{r}) {Animation[_animationIndex++ % Animation.Length]}";
                Console.ForegroundColor = percent < 50 ? ConsoleColor.DarkYellow : ConsoleColor.Yellow;
                UpdateText(text);
                Console.ForegroundColor = oldColor;
                ResetTimer();
            }
        }

        private void UpdateText(string text)
        {
            lock (_lock)
            {
                int commonPrefixLength = 0;
                int commonLength = Math.Min(_currentText.Length, text.Length);

                while (commonPrefixLength < commonLength && text[commonPrefixLength] == _currentText[commonPrefixLength]) commonPrefixLength++;

                int overlapCount = _currentText.Length - text.Length;

                StringBuilder outputBuilder = new();
                outputBuilder.Append('\b', _currentText.Length - commonPrefixLength);
                outputBuilder.Append(text, commonPrefixLength, text.Length - commonPrefixLength);

                if (overlapCount > 0)
                {
                    outputBuilder.Append(' ', overlapCount);
                    outputBuilder.Append('\b', overlapCount);
                }

                Console.Write(outputBuilder);
                _currentText = text;
            }
        }

        private void ResetTimer()
        {
            _timer.Change(_animationInterval, TimeSpan.FromMilliseconds(-1));
        }

        private void SetDone()
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            UpdateText(string.Empty);
            UpdateText($"[{new string('#', BlockCount)}] 100% ({f}/{r}) | Completed\n");
            Console.ForegroundColor = oldColor;
        }

        public void DoFailed(string errorMessage)
        {
            failedStatus = true;
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            UpdateText($"Failed: {errorMessage}");
            Console.ForegroundColor = oldColor;
        }

        public void Dispose()
        {
            lock (_lock)
            {
                if (_disposed) return;

                _disposed = true;
                if (!failedStatus) 
                    SetDone();
            }
        }
    }
}
