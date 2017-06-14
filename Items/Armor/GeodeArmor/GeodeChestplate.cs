using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GeodeArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class GeodeChestplate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode Chestplate");
			Tooltip.SetDefault("Increases  critical strike chance by 5%");
		}
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.value = Terraria.Item.sellPrice(0, 0, 75, 0);
            item.rare = 4;

            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 5;
            player.meleeCrit += 5;
      
            player.magicCrit += 5;
            player.rangedCrit += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
