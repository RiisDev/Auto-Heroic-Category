> [!IMPORTANT]
> The original project was created by [@arfonso01](https://github.com/arfonso01/) on [auto-heroic-categories](https://github.com/arfonso01/auto-heroic-categories)
> This is a remake in C#, with improved categories, and a progress bar.
> Made for windows, but will accept PR for linux & Mac OS.

# Auto Heroic Categories

Auto Heroic Categories, automatically categorizes your games from the 'heroic game launcher \
library' into custom categories using data from IGDB (Internet Game Database).

![](capture.gif)

### Requirements
* .NET 9.0 MINIMUM
* You need the igdb api, you can get access by following the steps in this [link](https://api-docs.igdb.com/?getting-started#account-creation)

### Configuration
The application will auto-generate a config file on first launch
* `CLIENT_ID`: IGDB API client ID, get it [here](https://dev.twitch.tv/console/apps/)
* `CLIENT_SECRET`: IGDB API client secret, create it [here](https://dev.twitch.tv/console/apps/)

### How to use
1) Sign in Heroic Launcher and all Gaming Accounts
2) **WAIT** for all games to load into Heroic
3) Create a temporary category (You can delete it later)
4) Close Heroic **fully**
5) Run executable and wait **If you close the application during runtime, it does not save its state** 
6) Launch Heroic to confirm it worked