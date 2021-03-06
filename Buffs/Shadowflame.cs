using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
	public class Shadowflame : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shadowflame");

			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.lifeRegen > 0)
				player.lifeRegen = 0;
			player.lifeRegen -= 12;
			if (Main.rand.Next(2) == 1)
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.Shadowflame);
			}
		}
	}
}
