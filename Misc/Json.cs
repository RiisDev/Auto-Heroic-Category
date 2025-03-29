using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HeroicCategory.Misc
{
    public static class Json
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            WriteIndented = true,
            IncludeFields = true,
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
        };

        public static string Serialize<TValue>(TValue obj, bool @unsafe = true)
        {
            string jsonBody = JsonSerializer.Serialize(obj, SerializerOptions);

            StringBuilder newBody = new(jsonBody.Length);

            bool insideValue = false;

            for (int i = 0; i < jsonBody.Length; i++)
            {
                if (jsonBody[i] == '"') insideValue = !insideValue;

                if (i + 1 < jsonBody.Length && jsonBody[i] == ' ' && jsonBody[i + 1] == ' ' && !insideValue)
                {
                    int indentCount = 0;

                    while (i + indentCount < jsonBody.Length && jsonBody[i + indentCount] == ' ') indentCount++;

                    int tabCount = indentCount / 2;
                    newBody.Append(new string('\t', tabCount));
                    i += indentCount - 1;
                }
                else newBody.Append(jsonBody[i]);
            }

            return newBody.ToString();

        }
    }
}
