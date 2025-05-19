using Code.Gameplay.Abilities;
using Code.Gameplay.Movement.Behaviours;
using Code.Gameplay.Projectiles;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
	[RequireComponent(typeof(IDamageApplier))]
	[RequireComponent(typeof(ProjectileAbilityHandler))]
	public class DestroyOnDamageApplied : MonoBehaviour
	{
		[SerializeField] private float _delay;
		
		private IDamageApplier _damageApplier;
		private ProjectileAbilityHandler _projectileAbilityHandler;

		private void Awake()
		{
			_damageApplier = GetComponent<IDamageApplier>();
			_projectileAbilityHandler = GetComponent<ProjectileAbilityHandler>();
		}

		private void OnEnable()
		{
			_damageApplier.OnDamageApplied += HandleDamageApplied;
		}

		private void OnDisable()
		{
			_damageApplier.OnDamageApplied -= HandleDamageApplied;
		}

		private void HandleDamageApplied(Health _)
		{
			if (_projectileAbilityHandler.IsProjectileAbilityObtained(AbilityId.BouncingProjectiles))
			{
				Vector3? newDirection = _projectileAbilityHandler.GetNextEnemyDirection();
				if (newDirection != null)
				{
					GetComponent<SettableMovementDirection>().SetDirection((Vector3)newDirection);
					return;
				}
			}
			
			if (_projectileAbilityHandler.IsProjectileAbilityObtained(AbilityId.PiercingProjectiles))
				return;

			Destroy(gameObject, _delay);
		}
	}
}