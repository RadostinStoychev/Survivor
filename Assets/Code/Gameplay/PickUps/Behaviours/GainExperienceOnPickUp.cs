using Code.Gameplay.Lifetime.Behaviours;
using UnityEngine;

namespace Code.Gameplay.PickUps.Behaviours
{
    [RequireComponent(typeof(PickUp))]
    public class GainExperienceOnPickUp : MonoBehaviour
    {
        [SerializeField] private int experienceAmount;
        
        private PickUp _pickUp;
        
        private void Awake()
        {
            _pickUp = GetComponent<PickUp>();
        }

        private void OnEnable()
        {
            _pickUp.OnPickUp += HandlePickup;
        }

        private void OnDisable()
        {
            _pickUp.OnPickUp -= HandlePickup;
        }

        private void HandlePickup(GameObject pickUpper)
        {
            if (pickUpper.TryGetComponent(out Experience experience))
            {
                experience.GainExperience(experienceAmount);
            }
        }
    }
}