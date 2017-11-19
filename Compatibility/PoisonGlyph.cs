using Terraria.ModLoader.IO;

namespace SpiritMod.Items.Glyphs
{
	public class PoisonGlyph : GlyphBase
	{
		public override string Texture => SpiritMod.EMPTY_TEXTURE;

		public override void Load(TagCompound tag)
		{
			item.SetDefaults(UnholyGlyph._type);
		}
	}
}