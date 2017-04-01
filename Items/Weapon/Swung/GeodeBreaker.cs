using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class GeodeBreaker : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Geode Breaker";
            item.damage = 34;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 32;
            item.useAnimation = 32;            
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 0, 70, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;   
            item.autoReuse = true;
            item.crit = 6;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 300, true);
            }
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 300, true);
            }
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.OnFire, 300, true);
            }
        }
    }
}
