using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
    public abstract class GlyphBase : ModItem
	{
		public const float GLOW_BIAS = 0.225f;

		private static GlyphBase[] _lookup = new GlyphBase[(byte)GlyphType.Count];
		public static GlyphBase FromType(GlyphType type) => _lookup[(byte)type];


		public abstract GlyphType Glyph { get; }
		public abstract Texture2D Overlay { get; }
		public virtual Color Color => Color.White;
		public abstract string Effect { get; }
		public abstract string Addendum { get; }

		public virtual bool CanApply(Item item)
		{
			return item.IsWeapon();
		}

		public sealed override bool CanRightClick()
		{
			Item item = Main.LocalPlayer.HeldItem;
			return !item.IsAir && item.GetGlobalItem<GItem>().Glyph != Glyph &&
				item.maxStack == 1 && CanApply(item);
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>().SetGlyph(item, Glyph);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			int index = tooltips.FindIndex(x => x.Name == "Tooltip0");
			if (index < 0)
				return;

			Player player = Main.player[Main.myPlayer];
			TooltipLine line;
			
			line = new TooltipLine(mod, "GlyphTooltip", "The enchanted item will gain: [c/"+
				string.Format("{0:X2}{1:X2}{2:X2}:", Color.R, Color.G, Color.B)+ Effect +"]");
			line.overrideColor = new Color(120, 190, 120);
			tooltips.Insert(index, line);

			if (CanRightClick())
				line = new TooltipLine(mod, "GlyphHint", "Right-click to enchant [i:"+ player.inventory[player.selectedItem].type +"]");
			else
				line = new TooltipLine(mod, "GlyphHint", "Hold the item you want to enchant,\nthen right-click this glyph.");
			line.overrideColor = new Color(120, 190, 120);
			tooltips.Insert(index, line);
		}

		public Item EnchantmentTarget(Player player)
		{
			if (player.selectedItem == 58)
				return Main.mouseItem;
			else
				return player.inventory[player.selectedItem];
		}


		internal static void InitializeGlyphLookup()
		{
			Type glyphBase = typeof(GlyphBase);
			foreach (Type type in SpiritMod.instance.Code.GetTypes())
			{
				if (type.IsAbstract)
					continue;
				if (!type.IsSubclassOf(glyphBase))
					continue;

				Item item = new Item();
				item.SetDefaults(SpiritMod.instance.ItemType(type.Name), true);
				GlyphBase glyph = (GlyphBase)item.modItem;
				_lookup[(byte)glyph.Glyph] = glyph;
			}

			GlyphBase zero = _lookup[0];
			for (int i = 1; i < _lookup.Length; i++)
			{
				if (_lookup[i] == null)
					_lookup[i] = zero;
			}
		}
	}
}