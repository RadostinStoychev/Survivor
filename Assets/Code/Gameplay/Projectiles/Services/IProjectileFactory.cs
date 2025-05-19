using System.Collections.Generic;
using Code.Gameplay.Abilities;
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Teams;
using Code.Gameplay.Vision.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Services
{
	public interface IProjectileFactory
	{
		Projectile CreateProjectile(Vector3 at, Vector2 direction, TeamType teamType, float damage, float movementSpeed, List<AbilityId> abilities, VisionSight visionSight);
	}
}