using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core.Commands;
using SDG.Unturned;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Permissions;
using Steamworks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using System.ComponentModel;
using Rocket.API;
using Rocket.API.Serialisation;
using Rocket.Core;
using Rocket.Core.Logging;
using Rocket.Unturned.Extensions;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Commands;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Rocket.API.Collections;
using System.Collections;
using System.Net;
using System.Threading;
using Rocket.Core.Extensions;
using Rocket.Core.Utils;
using UnityEngine.Assertions.Must;
using static SDG.Unturned.SleekBlueprint;

namespace DarkerAdmin
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;
        private Dictionary<CSteamID, bool[]> _clicks;
        protected override void Load()
        {
            Instance = this;
            this._clicks = new Dictionary<CSteamID, bool[]>();
            PlayerInput.onPluginKeyTick += PluginKeyTickHandler;
            UnturnedPlayerEvents.OnPlayerUpdateStamina += UnturnedPlayerEvents_OnPlayerUpdateStamina;
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateStamina(UnturnedPlayer player, byte stamina)
        {
            if (stamina < 80)
            {
                if (player.HasPermission(Configuration.Instance.permission))
                {
                    var cmp = player.GetComponent<PlayerComponent>();
                    if (cmp.Speed)
                    {
                        player.Player.life.serverModifyStamina(100);
                    }
                }
            }
        }

        public void PluginKeyTickHandler(Player player2, uint simulation, byte key, bool clicked)
        {
            UnturnedPlayer player = UnturnedPlayer.FromPlayer(player2);
            var cmp = player.GetComponent<PlayerComponent>();
            var cfg = Configuration.Instance;
            CSteamID steamID = player2.channel.owner.playerID.steamID;
            if (!this._clicks.ContainsKey(steamID))
            {
                this._clicks[steamID] = new bool[5];
            }
            if (this._clicks[steamID][(int)key] == clicked)
            {
                return;
            }
            this._clicks[steamID][(int)key] = clicked;
            if (!clicked)
            {
                return;
            }
            if (player.HasPermission(cfg.permission) | player.IsAdmin)
            {
                if (key == cfg.godbuttonid)
                {
                    if (player.GodMode)
                    {
                        player.GodMode = false;
                        ChatManager.serverSendMessage("Вы выключили режим бессмертия.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                    else
                    {
                        player.GodMode = true;
                        ChatManager.serverSendMessage("Вы включили режим бессмертия.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                }
                if(key == cfg.vanishgodbuttonid) 
                {
                    if (player.VanishMode)
                    {
                        player.VanishMode = false;
                        ChatManager.serverSendMessage("Вы выключили режим невидимости.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                    else
                    {
                        player.VanishMode = true;
                        ChatManager.serverSendMessage("Вы включили режим невидимости.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                }
                if (key == cfg.speedbuttonid)
                {
                    if (cmp.Speed)
                    {
                        player.Player.movement.sendPluginSpeedMultiplier(1f);
                        player.Player.movement.sendPluginJumpMultiplier(1f);
                        cmp.Speed = false;
                        ChatManager.serverSendMessage("Вы убрали админ-скорость.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                    else
                    {
                        player.Player.movement.sendPluginSpeedMultiplier(4f);
                        player.Player.movement.sendPluginJumpMultiplier(6f);
                        cmp.Speed = true;
                        ChatManager.serverSendMessage("Вы включили админ-скорость.", Color.yellow, null, player.SteamPlayer(), EChatMode.LOCAL);
                    }
                }
            }
        }
        protected override void Unload()
        {
            PlayerInput.onPluginKeyTick -= PluginKeyTickHandler;
        }
    }
}