using System;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Pishock
{
    public class PishockPlayer : ModPlayer
    {
        public override void PostHurt(Player.HurtInfo info)
        {
            Task.Run(async () =>
            {
                await Pishock.pishock_API.Shock(ModContent.GetInstance<Config>().Intensity, ModContent.GetInstance<Config>().Duration);
            });
        }
    }
}
