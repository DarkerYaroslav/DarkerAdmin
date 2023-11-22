using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using RoezTops;

namespace DarkerAdmin
{
    public class Config : IRocketPluginConfiguration
    {
        public string permission;
        public byte godbuttonid;
        public byte vanishgodbuttonid;
        public byte speedbuttonid;
        public void LoadDefaults()
        {
            permission = "admin";
            godbuttonid = 2;
            vanishgodbuttonid = 1;
            speedbuttonid = 0;
        }
    }
}
