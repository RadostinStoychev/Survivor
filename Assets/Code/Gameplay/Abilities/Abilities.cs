using System.Collections.Generic;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Abilities
{
    [RequireComponent(typeof(Stats))]
    public class Abilities : MonoBehaviour
    {
        private List<AbilityId> _heroAbilities = new List<AbilityId>();

        public List<AbilityId> GetHeroAbilities()
        {
            return _heroAbilities;
        }
    }
}