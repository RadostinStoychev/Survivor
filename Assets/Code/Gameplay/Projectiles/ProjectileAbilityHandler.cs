using System.Collections.Generic;
using Code.Gameplay.Abilities;
using Code.Gameplay.Vision.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Projectiles
{
    public class ProjectileAbilityHandler : MonoBehaviour
    {
        private List<AbilityId> _heroAbilitiesCache = new List<AbilityId>();
        private VisionSight _visionSight;

        public void SetAbilityHandler(List<AbilityId> abilities, VisionSight visionSight)
        {
            _heroAbilitiesCache = abilities;
            _visionSight = visionSight;
        }

        public bool IsProjectileAbilityObtained(AbilityId ability)
        {
            return _heroAbilitiesCache.Contains(ability);
        }

        public Vector3? GetNextEnemyDirection()
        {
            GameObject closestEnemy = _visionSight.GetClosestEnemy();

            if (closestEnemy == null)
            {
                return null;
            }
            
            return (_visionSight.GetClosestEnemy().transform.position - transform.position).normalized;
        }
    }
}