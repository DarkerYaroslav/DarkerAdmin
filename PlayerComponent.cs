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
using static Rocket.Unturned.Events.UnturnedPlayerEvents;

namespace DarkerAdmin
{
    public class PlayerComponent : UnturnedPlayerComponent
    {
        public bool Speed = false;
        protected override void Load()
        {

        }
        protected override void Unload()
        {

        }
    }
}
