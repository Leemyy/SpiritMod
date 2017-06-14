using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class FelBrand : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fel Brand");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage = (int)(npc.damage * 0.88f);
            npc.GetModInfo<NInfo>(mod).felBrand = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 75);
                Main.dust[dust].scale = 2f;
                Main.dust[dust].noGravity = true;
            }
        }

    }
}
