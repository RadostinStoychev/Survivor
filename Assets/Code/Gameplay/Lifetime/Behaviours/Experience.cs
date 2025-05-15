using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
    public class Experience : MonoBehaviour
    {
        [field: SerializeField] public float CurrentExperience { get; private set; }
        [field: SerializeField] public float ExperienceToNextLevel { get; private set; }
        
        public event Action<float> OnExperienceChanged;
        public event Action OnLevelUp;
        
        public void GainExperience(float experienceAmount)
        {
            // Level up if target is reached.
            if (experienceAmount + CurrentExperience >= ExperienceToNextLevel)
            {
                CurrentExperience = (experienceAmount + CurrentExperience) - ExperienceToNextLevel;
                OnLevelUp?.Invoke();
            }
            else
            {
                CurrentExperience += experienceAmount;
            }
            
            OnExperienceChanged?.Invoke(experienceAmount);
        }
    }
}