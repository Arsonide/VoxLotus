Vox Lotus v0.14b

-- SUMMARY --

Vox Lotus is a standalone system tray application for the game Warframe. It announces alerts, invasions, and other events that are occurring in-game using tray notifications and audible text to speech. These announcements can be extensively configured, tweaked, and filtered based on your preferences.

-- FEATURES --

There are many programs and websites for Warframe that do what Vox Lotus does. Let’s go over the basic common features of these programs first.
 * They provide notifications for alerts, invasions, and other in-game events as they occur.
 * They do not require you to log in to the game (or anything else) to see these notifications.
 * The notifications show the rewards of the events they are displaying.
 * The program allows you to filter your notifications, to only see events that provide rewards you want.

-- DIFFERENCES --

Now we will go over what makes Vox Lotus different from other programs.

Audibility: Vox Lotus optionally uses text to speech, which is what it is actually named after. This lets you know what is occurring in Warframe without having to minimize what you are doing, or even having to get out of bed if you are using speakers.

Reliability: Most of these programs disassemble tweets coming off of Warframe’s Twitter feed. This is prone to errors because if those tweets ever change their format, the programs will no longer function. Also, due to the short nature of a tweet, not much metadata about the event can be provided, which means the program or website cannot do much with it. Vox Lotus utilizes the official world state API that Digital Extremes provides for Warframe. This provides a lot more metadata for filtering your preferences, and it is less prone to errors in the future.

Functionality: Vox Lotus does more than notify you about alerts and invasions. It can also notify you when dailies, faction standings, sorties, and syndicate missions reset. It can notify you when the day-night cycles change in Cetus, or on Earth. It also has a (manually controlled) timer system to keep track of your extractor harvesting. It also shows you in real time, how long until these events occur.

Efficiency: Vox Lotus gives you more control over your notifications than simply “notify me” or “do not notify me”. There is a middle setting for every single reward: “notify me if the mission is not tedious”. What the program considers “tedious” by default, is endless missions such as Interception, Defense, and Survival. This can be configured, but we’ll get to that in a bit. This feature allows you to, for instance, get notifications for alerts that provide 150 Endo, but only if they are for quick capture missions. This allows you to be more efficient by wasting less of your time on things that you would never be interested in.

Granularity: Several other programs allow you to filter using broad categories, like “Helmets”. There are a lot of helmets in Warframe these days, and while I want some of them, I do not want all of them. Vox Lotus allows you to filter for individual rewards, rather than broad categories of them.

Configurability: Every single planet and reward in Vox Lotus is loaded from a configuration file - not hard coded. This means that the program will not need to be recompiled every time a reward or planet is added to the game. They can be added to the configuration file. This also allows control over other things, like how a reward is pronounced, and what missions are considered tedious for each individual reward using a special “tedious” tag. For more information on how to configure Vox Lotus, the wiki has several articles that go over this process in great detail.

-- INSTALLATION --

Releases will come packaged as a zip file. Extract that somewhere, and run it. It is that simple. Please note that the program requires .NET Framework 4.6+. It also obviously requires an active internet connection.

-- TROUBLESHOOTING --

The wiki has guides explaining how to use and configure Vox Lotus. The release page will have new versions as they are released. The issue tracker is where you should post any bugs you run into. If there is an “error.log” file in the directory with Vox Lotus, please provide that in any issues you post as it will greatly assist me in fixing the problem. Links to these pages are located at the bottom of this file.
 
-- LEGAL --

 * Utilizes Warframe.NET and Newtonsoft.JSON.
 * Originally based off of WarframeAlerts, but has been significantly overhauled internally.
 * All available licenses have been compiled into a single license file included with this release.
 
 -- LINKS --

 * Main: https://github.com/Arsonide/VoxLotus
 * Wiki: https://github.com/Arsonide/VoxLotus/wiki
 * Releases: https://github.com/Arsonide/VoxLotus/releases
 * Issue Tracker: https://github.com/Arsonide/VoxLotus/issues

 * .NET Framework: https://www.microsoft.com/net/download/framework
 * Warframe.NET: https://github.com/WFCD/warframe-net
 * Newtonsoft.JSON: https://github.com/JamesNK/Newtonsoft.Json
 * WarframeAlerts: https://github.com/thquinn/WarframeAlerts