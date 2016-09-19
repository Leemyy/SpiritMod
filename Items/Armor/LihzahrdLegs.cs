using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class LihzahrdLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Lihzahrd Legs";
            item.width = 22;
            item.height = 18;
            item.value = 10;
			item.toolTip = "Increased Thrown Damage";
            item.rare = 1;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player)
        {
			player.moveSpeed += 0.2f;
			player.thrownDamage += 0.05f;
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 40);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}