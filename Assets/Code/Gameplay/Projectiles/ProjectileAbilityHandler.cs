using System.Collections.Generic;
using Code.Gameplay.Abilities;
using UnityEngine;

namespace Code.Gameplay.Projectiles
{
    public class ProjectileAbilityHandler : MonoBehaviour
    {
        private List<AbilityId> _heroAbilitiesCache = new List<AbilityId>();

        public void SetHeroAbilitiesCurrentState(List<AbilityId> abilities)
        {
            _heroAbilitiesCache = abilities;
        }

        public bool IsProjectileAbilityObtained(AbilityId ability)
        {
            return _heroAbilitiesCache.Contains(ability);
        }
    }
}