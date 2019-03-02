using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaExtra.Projectiles
{
	public class HallowedGlass : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Glass");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GreenLaser);
			aiType = ProjectileID.GreenLaser;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.GreenLaser;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 0; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 4f, Main.rand.Next(-3, 2) * .12f, Main.rand.Next(-3, -2) * .12f, ProjectileID.GreenLaser, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}

			public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(BuffID.Ichor, 500);
			}
		}
	}
}