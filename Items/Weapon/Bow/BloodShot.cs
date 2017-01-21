using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using SpiritMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class BloodShot : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Bloodshot";
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.width = 24;
            item.height = 46;
            item.useTime = 22;
            item.toolTip = "Arrows shot inflict Blood Corruption";
            item.useAnimation = 22;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 4;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 5f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[p].GetModInfo<SpiritProjectileInfo>(mod).shotFromBloodshot = true;
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodFire", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
