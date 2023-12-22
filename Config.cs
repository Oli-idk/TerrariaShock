using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Pishock
{
    internal class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Shocker")]
        public string username;
        public string apiKey;
        public string code;
        [DefaultValue("Terraria Mod")]
        public string senderName;

        [DefaultValue("https://do.pishock.com/api/apioperate/")]
        public string apiEndpoint;

        [Header("Punishment")]
        [DefaultValue(10)]
        [Range(0, 100)]
        public int Intensity;
        [DefaultValue(1)]
        [Range(0, 10)]
        public int Duration;
    }
}
