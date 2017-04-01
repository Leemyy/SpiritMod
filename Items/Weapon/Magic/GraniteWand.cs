using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class GraniteWand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Granite Wand"; 
            item.damage = 19;
            item.magic = true;
            item.mana = 8;
            item.width = 44;
            item.height = 44;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 3;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.crit = 10;
            item.UseSound = SoundID.Item9;
            item.shoot = mod.ProjectileType("GraniteSpike1");
            item.shootSpeed = 8f;
            item.toolTip = "Shoots a blast of Granite Energy that splits into bolts on hit \n Critical hits inflict Energy Flux";
            item.autoReuse = false;
        }

            public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GraniteChunk", 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
