using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles
{
	public class CultDagger : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sacrificial Dagger");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 800;
			projectile.tileCollide = true;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
		}

		public override bool PreAI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;

			for (int i = 0; i < 10; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, 206, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, 206, 0f, 0f, 0, default(Color), 1f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if (Main.rand.Next(2) == 0)
			{
				player.statMana += 3;
				player.ManaEffect(3);
			}
		}

	}
}