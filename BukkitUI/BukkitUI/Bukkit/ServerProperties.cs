using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace BukkitUI.Bukkit {
    class ServerProperties {

        #region Properties
        // I'd like to note; I'm going after the Minecraft Wiki, here - I'm using that order...
        [Category("Boolean Values"), Description("Allows users to use flight on your server while in Survival mode, if they have a mod that provides flight installed.\n"
        + "With allow-flight enabled griefers will possibly be more common, because it will make their work easier. In Creative mode this has no effect.\n"
        + "false - Flight is not allowed (players in air for at least 5 seconds will be kicked).\n"
        + "true - Flight is allowed, and used if the player has a fly mod installed. ")]
        public bool allowFlight { get; set; }

        [Category("Boolean Values"), Description("Allows players to travel to the Nether.\n"
            + "false - Nether portals will not work."
            + "true - The server will allow portals to send players to the Nether. ")]
        public bool allowNether { get; set; }

        [Category("Boolean Values"), Description("Allows server to announce when a player gets an achievement.")]
        public bool announcePlayerAchievements { get; set; }

        [Category("Misc. Values"), Description("Defines the difficulty (such as damage dealt by mobs and the way hunger and poison affects players) of the server. ")]
        public ServerDifficulty difficulty { get; set; }

        [Category("Boolean Values"), Description("Enables GameSpy4 protocol server listener. Used to get information about server.")]
        public bool enableQuery { get; set; }

        [Category("Boolean Values"), Description("Enables remote access to the server console.")]
        public bool enableRcon { get; set; }

        [Category("Boolean Values"), Description("Enables command blocks")]
        public bool enableCmdBlock { get; set; }

        [Category("Boolean Values"), Description("Force players to join in the default game mode.\n"
            + "false - Players will join in the gamemode they left in.\n"
            + "true - Players will always join in the default gamemode. ")]
        public bool forceGamemode { get; set; }

        [Category("Misc. Values"), Description("Defines the mode of gameplay. ")]
        public Gamemode gamemode { get; set; }

        [Category("Boolean Values"), Description("Defines whether structures (such as villages) will be generated.\n"
            + "false - Structures will not be generated in new chunks.\n"
            + "true - Structures will be generated in new chunks.\n"
            +  "Note: Dungeons and Nether Fortresses will still generate if this is set to false.")]
        public bool generateStructures { get; set; }

        [Category("String Values"), Description("The settings used to customize Superflat world generation. See Superflat for possible settings and examples.")]
        public String generatorSettings { get; set; }

        [Category("Boolean Values"), Description("If set to true, players will be permanently banned if they die.")]
        public bool isHardcore { get; set; } // I swear to <enter deity here>, don't think that way.

        [Category("String Values"), Description("The \"level-name\" value will be used as the world name and its folder name.\n"
            + "You may also copy your saved game folder here, and change the name to the same as that folder's to load it instead.\n"
            + "Characters such as ' (apostrophe) may need to be escaped by adding a backslash before them. ")]
        public String levelName { get; set; }

        [Category("String Values"), Description("Add a seed for your world, as in Singleplayer.")]
        public String levelSeed { get; set; }

        [Category("Misc. Values"), Description("Determines the type of map that is generated.\n"
            + "DEFAULT - Standard world with hills, valleys, water, etc.\n"
            + "FLAT - A flat world with no features, meant for building.\n"
            + "LARGEBIOMES - Same as default but all biomes are larger.\n"
            + "AMPLIFIED - Same as default but world-generation height limit is increased.\n"
            + "CUSTOMIZED - Since snapshot 14w21b, servers also support the custom terrain. First you have to generate a customized world in singleplayer and copy it to the server. ")]
        public LevelType levelType { get; set; }

        [Category("Number Values"), Description("The maximum height in which building is allowed. Terrain may still naturally generate above a low height limit.")]
        public int maxBuildHeight { get; set; }

        [Category("Number Values"), Description("The maximum number of players that can play on the server at the same time.\n"
            + "Note that if more players are on the server it will use more resources.\n"
            + "Note also, op player connections are not supposed to count against the max players, but ops currently cannot join a full server.\n"
            + "Extremely large values for this field result in the client-side user list being broken.")]
        public int maxPlayers { get; set; }

        [Category("String Values"), Description("This is the message that is displayed in the server list of the client, below the name.\n"
        + "The MOTD does support color and formatting codes.\n"
        + "If the MOTD is over 59 characters, the server list will likely report a communication error.")]
        public String motd { get; set; }

        [Category("Number Values"), Description("By default it allows packets that are n-1 bytes big to go normally, but a packet that n bytes or more will be compressed down.\n"
        + "So, lower number means more compression but compressing small amounts of bytes might actually end up with a larger result than what went in.\n"
        + "-1 - disable compression entirely\n"
        + "0 - compress everything ")]
        public int networkCompressionMode { get; set; } // A feature most likely coming with the 1.8 servers (1.6.4 is still the recommended one)

        [Category("Boolean Values"), Description("Server checks connecting players against minecraft's account database.\n"
        + "Only set this to false if your server is not connected to the Internet. Hackers with fake accounts can connect if this is set to false!\n"
        + "If minecraft.net is down or inaccessible, no players will be able to connect if this is set to true.\n"
        + "Setting this variable to off purposely is called \"cracking\" a server, and servers that are presently with online mode off are called \"cracked\" servers\n"
        + "allowing players with unlicensed copies of Minecraft to join.\n"
        + "true - Enabled. The server will assume it has an Internet connection and check every connecting player.\n"
        + "false - Disabled. The server will not attempt to check connecting players. ")]
        public bool onlineMode { get; set; }

        [Category("Number Values"), Description("Sets permission level for ops.\n"
            + "1 - Ops can bypass spawn protection.\n"
            + "2 - Ops can use /clear, /difficulty, /effect, /gamemode, /gamerule, /give, and /tp, and can edit command blocks.\n"
            + "3 - Ops can use /ban, /deop, /kick, and /op.\n"
            + "4 - Ops can use /stop. ")]
        public short opPermissionLevel { get; set; }

        [Category("Number Values"), Description("If non-zero, players are kicked from the server if they are idle for more than that many minutes. ")]
        public short playerIdleTimeout { get; set; }

        [Category("Boolean Values"), Description("Enable PvP on the server. Players shooting themselves with arrows will only receive damage if PvP is enabled.\n"
        + "Note: Indirect damage sources spawned by players (such as lava, fire, TNT and to some extent water, sand and gravel) will still deal damage to other players.\n"
        + "true - Players will be able to kill each other.\n"
        + "false - Players cannot kill other players (also known as Player versus Environment (PvE)). ")]
        public bool enablePVP { get; set; }

        [Category("Number Values"), Description("Sets the port for the query server (see enable-query).")]
        public short queryPort { get; set; }

        [Category("String Values"), Description("Sets the password to rcon.")]
        public String rconPassword { get; set; }

        [Category("Number Values"), Description("Sets the port to rcon.")]
        public short rconPort { get; set; }

        [Category("String Values"), Description("Server prompts client to download resource pack upon join. This link must be a direct link to the actual resource pack .zip file.")]
        public String resourcePack { get; set; }

        [Category("String Values"), Description("Set this if you want the server to bind to a particular IP. It is strongly recommended that you leave server-ip blank!\n"
        + "Set to blank, or the IP you want your server to run (listen) on. ")]
        public String serverIP { get; set; }

        [Category("String Values"), Description("The name of your server.")]
        public String serverName { get; set; }

        [Category("Number Values"), Description("Changes the port the server is hosting (listening) on.\n"
        + "This port must be forwarded if the server is hosted in a network using NAT (If you have a home router/firewall).")]
        public short serverPort { get; set; }

        [Category("Boolean Values"), Description("Sets whether the server sends snoop data regularly to http://stats.minecraft.net.\n"
            + "false - disable snooping.\n"
            + "true - enable snooping. ")]
        public bool snooperEnabled { get; set; }

        [Category("Boolean Values"), Description("Determines if animals will be able to spawn.\n"
            + "true - Animals spawn as normal.\n"
            + "false - Animals will immediately vanish.\n"
            + "Tip: if you have major lag, turn this off/set to false.")]
        public bool spawnAnimals { get; set; }

        [Category("Boolean Values"), Description("Determines if monsters will be spawned.\n"
            + "true - Enabled. Monsters will appear at night and in the dark.\n"
            + "false - Disabled. No monsters.\n"
            + "This does nothing if difficulty = 0 (peaceful) Unless your difficulty is not set to 0, when a monster can still spawn from a Monster Spawner.\n"
            + "Tip: if you have major lag, turn this off/set to false.")]
        public bool spawnMonsters { get; set; }

        [Category("Boolean Values"), Description("Determines if villagers will be spawned.\n"
            + "true - Enabled. Villagers will spawn.\n"
            + "false - Disabled. No villagers. ")]
        public bool spawnNPCs { get; set; }

        [Category("Number Values"), Description("Determines the radius of the spawn protection. Setting this to 0 will not disable spawn protection.\n"
            + "0 will protect the single block at the spawn point. 1 will protect a 3x3 area centered on the spawn point.\n"
            + "2 will protect 5x5, 3 will protect 7x7, etc. This option is not generated on the first server start and appears when the first player joins.\n"
            + "If there are no ops set on the server, the spawn protection will be disabled automatically.")]
        public int spawnProtection { get; set; }

        [Category("Number Values"), Description("Sets the amount of world data the server sends the client, measured in chunks in each direction of the player (radius, not diameter).\n"
            + "It determines the server-side viewing distance. The \"Far\" viewing distance is 16 chunks, sending 1089 total chunks\n"
            + "(the amount of chunks that the server will load can be seen in the debug screen). \"Normal\" view distance is 8, for 289 chunks.\n"
            + "10 is the default/recommended. If you have major lag, reduce this value.")]
        public short viewDistance { get; set; }

        [Category("Boolean Values"), Description("Enables a whitelist on the server.\n"
            + "With a whitelist enabled, users not on the whitelist will be unable to connect.\n"
            + "Intended for private servers, such as those for real-life friends or strangers carefully selected via an application process, for example.\n"
            + "Note - Ops are automatically white listed, and there is no need to add them to the whitelist.\n"
            + "false - No white list is used.\n"
            + "true - The file white-list.txt is used to generate the white list. ")]
        public bool useWhiteList { get; set; }
        #endregion

        private String bukkitDir { get; set; }

        /// <summary>
        /// Careful. This is one big-assed method...
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            // Don't say I didn't warn ya...
            StringBuilder val = new StringBuilder();
            val.Append("# Minecraft Bukkit Server Properties\n");
                 val.Append("# Generated " + DateTime.Now.ToString());
                 val.Append("by BukkitUI for Windows\n");
                 val.Append("# Please do not edit these settings outside of BukkitUI, as this might cause\n");
                 val.Append("# an unpleasent surprise :) (I won't go too technical, but you might blow a\n");
                 val.Append("# hole in the spacetime-continuum)\n\n");
                 
                 val.Append("# Start settings:\n");
                 val.Append("allow-flight=" + allowFlight.ToString() + "\n");
                 val.Append("allow-nether=" + allowNether.ToString() + "\n");
                 val.Append("announce-player-achievement=" + announcePlayerAchievements.ToString() + "\n");
                 val.Append("difficulty=");
            switch (difficulty) {
                case ServerDifficulty.Peaceful:
                    val.Append("0\n");
                    break;
                case ServerDifficulty.Easy:
                    val.Append("1\n");
                    break;
                case ServerDifficulty.Normal:
                    val.Append("2\n");
                    break;
                case ServerDifficulty.Hard:
                    val.Append("3\n");
                    break;
                default:
                    val.Append("2\n");
                    break;
            }
            val.Append("enable-query=" + enableQuery.ToString() + "\n");
            val.Append("enable-rcon=" + enableRcon.ToString() + "\n");
            val.Append("enable-command-block=" + enableCmdBlock.ToString() + "\n");
            val.Append("force-gamemode=" + forceGamemode.ToString() + "\n");
            val.Append("gamemode=");
            switch (gamemode) {
                case Gamemode.Survival:
                    val.Append("0\n");
                    break;
                case Gamemode.Creative:
                    val.Append("1\n");
                    break;
                case Gamemode.Adventure:
                    val.Append("2\n");
                    break;
                case Gamemode.Spectator:
                    val.Append("3\n");
                    break;
                default:
                    val.Append("0\n");
                    break;
            }
            val.Append("generate-structures=" + generateStructures.ToString() + "\n");
            val.Append("generator-settings=" + generatorSettings + "\n");
            val.Append("hardcore=" + isHardcore.ToString() + "\n");
            val.Append("level-name=" + levelName + "\n");
            val.Append("level-seed=" + levelSeed + "\n");
            val.Append("level-type=" + levelType.ToString() + "\n");
            val.Append("max-build-height=" + maxBuildHeight.ToString() + "\n");
            val.Append("max-players=" + maxPlayers.ToString() + "\n");
            val.Append("motd=" + motd + "\n");
            val.Append("network-compression-threshold=" + networkCompressionMode.ToString() + "\n");
            val.Append("online-mode=" + onlineMode.ToString() + "\n");
            val.Append("op-permission-level=" + opPermissionLevel.ToString() + "\n");
            val.Append("player-idle-timeout=" + playerIdleTimeout.ToString() + "\n");
            val.Append("pvp=" + enablePVP.ToString() + "\n");
            val.Append("query.port=" + queryPort.ToString() + "\n");
            val.Append("rcon.password=" + rconPassword + "\n");
            val.Append("rcon.port=" + rconPort.ToString() + "\n");
            val.Append("resource-pack=" + resourcePack + "\n");
            val.Append("server-ip=" + serverIP + "\n");
            val.Append("server-name=" + serverName + "\n");
            val.Append("server-port=" + serverPort.ToString() + "\n");
            val.Append("snooper-enabled=" + snooperEnabled.ToString() + "\n");
            val.Append("spawn-animals=" + spawnAnimals.ToString() + "\n");
            val.Append("spawn-monsters=" + spawnMonsters.ToString() + "\n");
            val.Append("spawn-npcs=" + spawnNPCs.ToString() + "\n");
            val.Append("spawn-protection=" + spawnProtection.ToString() + "\n");
            val.Append("view-distance=" + viewDistance.ToString() + "\n");
            val.Append("white-list=" + useWhiteList.ToString() + "\n");
            val.Append("# End Properties...");

            return val.ToString();
        }

        public ServerProperties(String bukkitDir, bool forceReset) {
            this.bukkitDir = bukkitDir;
            loadProperties(forceReset);
        }

        public void loadProperties(bool forceReset) {
            // Check if server.properties file exists or not.
            // If it doesn't exist, or forceReset, then the values will be set to the defaults
            // and the file will become complete stock. If you didn't already figure that out.
            // Yes, I'm not very nice to people :p
            if (!File.Exists(Path.Combine(bukkitDir, "server.properties")) || forceReset) {
                allowFlight = false;
                allowNether = true;
                announcePlayerAchievements = true;
                difficulty = ServerDifficulty.Normal;
                enableQuery = false;
                enableRcon = false;
                enableCmdBlock = false;
                forceGamemode = false;
                gamemode = Gamemode.Survival;
                generateStructures = true;
                generatorSettings = "";
                isHardcore = false;
                levelName = ".world";
                levelSeed = "";
                levelType = LevelType.Default;
                maxBuildHeight = 265;
                maxPlayers = 25;
                motd = "Powered by BukkitUI for Windows!";
                networkCompressionMode = 0;
                onlineMode = true;
                opPermissionLevel = 4;
                playerIdleTimeout = 0;
                enablePVP = true;
                queryPort = 25565;
                rconPassword = "";
                resourcePack = "";
                serverIP = "";
                serverName = "BukkitUI Minecraft Server";
                serverPort = 25565;
                snooperEnabled = true;
                spawnAnimals = true;
                spawnMonsters = true;
                spawnNPCs = true;
                spawnProtection = 16;
                viewDistance = 10;
                useWhiteList = false;
                saveProperties();
                return;
            }

            // Load properties
            String output = File.ReadAllText(Path.Combine(bukkitDir, "server.properties"));

            using (StringReader reader = new StringReader(output)) {
                String line;
                while ((line = reader.ReadLine()) != null) {
                    if (line.StartsWith("#") || line.Equals("")) continue;
                    String[] split = line.Split('=');
                    #region Parser
                    switch (split[0]) {
                        case "allow-flight":
                            allowFlight = bool.Parse(split[1]);
                            break;
                        case "allow-nether":
                            allowNether = bool.Parse(split[1]);
                            break;
                        case "announce-player-achievements":
                            announcePlayerAchievements = bool.Parse(split[1]);
                            break;
                        case "difficulty":
                            switch (int.Parse(split[1])) {
                                case 0:
                                    difficulty = ServerDifficulty.Peaceful;
                                    break;
                                case 1:
                                    difficulty = ServerDifficulty.Easy;
                                    break;
                                case 2:
                                    difficulty = ServerDifficulty.Normal;
                                    break;
                                case 3:
                                    difficulty = ServerDifficulty.Hard;
                                    break;
                                default:
                                    difficulty = ServerDifficulty.Normal;
                                    break;
                            }
                            break;
                        case "enable-query":
                            enableQuery = bool.Parse(split[1]);
                            break;
                        case "enable-rcon":
                            enableRcon = bool.Parse(split[1]);
                            break;
                        case "enable-command-block":
                            enableCmdBlock = bool.Parse(split[1]);
                            break;
                        case "force-gamemode":
                            forceGamemode = bool.Parse(split[1]);
                            break;
                        case "gamemode":
                            switch (int.Parse(split[1])) {
                                case 0:
                                    gamemode = Gamemode.Survival;
                                    break;
                                case 1:
                                    gamemode = Gamemode.Creative;
                                    break;
                                case 2:
                                    gamemode = Gamemode.Adventure;
                                    break;
                                case 3:
                                    gamemode = Gamemode.Spectator;
                                    break;
                                default:
                                    gamemode = Gamemode.Survival;
                                    break;
                            }
                            break;
                        case  "generate-structures":
                            generateStructures = bool.Parse(split[1]);
                            break;
                        case "generator-settings":
                            generatorSettings = split[1];
                            break;
                        case "hardcore":
                            isHardcore = bool.Parse(split[1]);
                            break;
                        case "level-name":
                            levelName = split[1];
                            break;
                        case "level-seed":
                            levelSeed = split[1];
                            break;
                        case "level-type":
                            switch (split[1].ToUpper()) {
                                case "DEFAULT":
                                    levelType = LevelType.Default;
                                    break;
                                case "FLAT":
                                    levelType = LevelType.Flat;
                                    break;
                                case "LARGEBIOMES":
                                    levelType = LevelType.LargeBiomes;
                                    break;
                                case "AMPLIFIED":
                                    levelType = LevelType.Amplified;
                                    break;
                                case "CUSTOMIZED":
                                    levelType = LevelType.Customized;
                                    break;
                                default:
                                    levelType = LevelType.Default;
                                    break;
                            }
                            break;
                        case "max-build-height":
                            maxBuildHeight = int.Parse(split[1]);
                            break;
                        case "max-players":
                            maxPlayers = int.Parse(split[1]);
                            break;
                        case "motd":
                            motd = split[1];
                            break;
                        case "network-compression-threshold":
                            networkCompressionMode = int.Parse(split[1]);
                            break;
                        case "online-mode":
                            onlineMode = bool.Parse(split[1]);
                            break;
                        case "op-permission-level":
                            opPermissionLevel = short.Parse(split[1]);
                            break;
                        case "player-idle-timeout":
                            playerIdleTimeout = short.Parse(split[1]);
                            break;
                        case "pvp":
                            enablePVP = bool.Parse(split[1]);
                            break;
                        case "query.port":
                            queryPort = short.Parse(split[1]);
                            break;
                        case "rcon.password":
                            rconPassword = split[1];
                            break;
                        case "rcon.port":
                            rconPort = short.Parse(split[1]);
                            break;
                        case "resource-pack":
                            resourcePack = split[1];
                            break;
                        case "server-ip":
                            serverIP = split[1];
                            break;
                        case "server-name":
                            serverName = split[1];
                            break;
                        case "server--port":
                            serverPort = short.Parse(split[1]);
                            break;
                        case "snooper-enabled":
                            snooperEnabled = bool.Parse(split[1]);
                            break;
                        case "spawn-animals":
                            spawnAnimals = bool.Parse(split[1]);;
                            break;
                        case "spawn-monsters":
                            spawnMonsters = bool.Parse(split[1]);
                            break;
                        case "spawn-npcs":
                            spawnNPCs = bool.Parse(split[1]);
                            break;
                        case "spawn-protection":
                            spawnProtection = int.Parse(split[1]);
                            break;
                        case "view-distance":
                            viewDistance = short.Parse(split[1]);
                            break;
                        case "white-list":
                            useWhiteList = bool.Parse(split[1]);
                            break;
                    } 
                #endregion
                }
                reader.Close();
                reader.Dispose();
            }

        }

        public void saveProperties() {
            if (!File.Exists(Path.Combine(bukkitDir, "server.properties")))
                File.Create(Path.Combine(bukkitDir, "server.properties")).Close();
            File.WriteAllText(Path.Combine(bukkitDir, "server.properties"), ToString());
        }

    }
}
