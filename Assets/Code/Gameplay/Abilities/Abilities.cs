using System.Collections.Generic;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Abilities
{
    [RequireComponent(typeof(Stats))]
    public class Abilities : MonoBehaviour
    {
        private readonly List<AbilityId> _heroAbilities = new List<AbilityId>();

        public List<AbilityId> GetHeroAbilities()
        {
            return _heroAbilities;
        }

        public bool IsAbilityObtained(AbilityId abilityId)
        {
            return _heroAbilities.Contains(abilityId);
        }
        
        public void ObtainAbility(AbilityId abilityId)
        {
            _heroAbilities.Add(abilityId);
            ApplyStatAbilityEffect(abilityId);
        }

        private void ApplyStatAbilityEffect(AbilityId abilityId)
        {
            Stats stats = GetComponent<Stats>();
            
            switch (abilityId)
            {
                case AbilityId.DamageUp:
                    stats.SetBaseStat(StatType.Damage, stats.GetStat(StatType.Damage) + 1);
                    break;
                case AbilityId.HealthUp:
                    stats.SetBaseStat(StatType.MaxHealth, stats.GetStat(StatType.MaxHealth) + 1);
                    break;
                case AbilityId.AgilityUp:
                    stats.SetBaseStat(StatType.RotationSpeed, stats.GetStat(StatType.RotationSpeed) + 1);
                    break;
            }
        }
    }
}