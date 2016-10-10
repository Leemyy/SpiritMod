using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class CursedFire : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cursed Fire";
            item.width = 22;
            item.height = 36;
            item.value = 5000;
            item.rare = 4;

            item.maxStack = 999;
        }

        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 3);
            recipe.AddIngredient(ItemID.Ectoplasm);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}