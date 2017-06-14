using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Rune : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Rune");
			Tooltip.SetDefault("'It's inscribed in some archaic language'");
		}


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 42;
            item.value = 100;
            item.rare = 5;
            item.maxStack = 999;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
        }
		public override DrawAnimation GetAnimation()
		{
			// ticksperframe, frameCount
			return new DrawAnimationVertical(8, 5);
		}
    }
}