using System;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
    [RequireComponent(typeof(Stats))]
    public class Experience : MonoBehaviour
    {
        [field: SerializeField] public float CurrentExperience { get; private set; }
        [field: SerializeField] public float ExperienceToNextLevel { get; private set; }
        
        public event Action OnLevelUp;
        
        public void GainExperience(float experienceAmount)
        {
            // Level up if target is reached.
            if (experienceAmount + CurrentExperience >= ExperienceToNextLevel)
            {
                CurrentExperience = (experienceAmount + CurrentExperience) - ExperienceToNextLevel;
                Stats stats = GetComponent<Stats>();
                stats.SetBaseStat(StatType.Level, stats.GetStat(StatType.Level) + 1);
                OnLevelUp?.Invoke();
            }
            else
            {
                CurrentExperience += experienceAmount;
            }
        }
    }
}