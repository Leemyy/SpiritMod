using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown.Artifact
{
	public class DeathRot4 : ModItem
    {
        int charger;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Rot");
            Tooltip.SetDefault("'You have become the Artifact Keeper of Pestilence'\nHit enemies are afflicted by 'Necrosis,'\nEvery fifth throw of the weapon leaves behind multiple clouds of Plague Miasma\nAttacks may release a swarm of Rot Seekers that explode into violent fumes\nCritical hits may cause enemies to explode into violent fumes\nHitting enemies will may release Nectrotic Embers\n~Artifact Weapon~");

        }


        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.width = 52;
            item.height = 56;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item100;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("DeathRot4Proj");
            item.useAnimation = 13;
            item.consumable = true;
            item.useTime = 13;
            item.crit = 4;
            item.shootSpeed = 11f;
            item.damage = 63;
            item.knockBack = 2.9f;
            item.value = Item.sellPrice(0, 12, 0, 50);
            item.rare = 10;
            item.autoReuse = true;
            item.maxStack = 1;
            item.consumable = false;
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            charger++;
            if (charger >= 5)
            {
                for (int I = 0; I < 3; I++)
                {
                    Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-230, 230) / 100), speedY + ((float)Main.rand.Next(-230, 230) / 100), mod.ProjectileType("Miasma"), damage, knockBack, player.whoAmI, 0f, 0f);
                }
                charger = 0;
            }
            if (Main.rand.Next(4) == 1)
            {
                for (int I = 0; I < 3; I++)
                {
                    Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-130, 130) / 100), speedY + ((float)Main.rand.Next(-130, 130) / 100), mod.ProjectileType("RotSeeker"), 50, knockBack, player.whoAmI, 0f, 0f);

                }
            }
                return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DeathRot3", 1);
            recipe.AddIngredient(null, "RadiantEmblem", 1);
            recipe.AddIngredient(null, "PlanteraBloom", 1);
            recipe.AddIngredient(null, "UnrefinedRuneStone", 1);
            recipe.AddIngredient(null, "Catalyst", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 150);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
