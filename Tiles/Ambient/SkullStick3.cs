using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace SpiritMod.Tiles.Ambient
{
    public class SkullStick3 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
            TileObjectData.addTile(Type);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
            16,
            16,
            16
            };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            AddMapEntry(new Color(193, 158, 32), "Skull Stick");
            adjTiles = new int[] { TileID.Lamps };
        }

    }
}