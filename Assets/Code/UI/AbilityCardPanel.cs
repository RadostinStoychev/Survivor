using Code.Gameplay.Abilities;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class AbilityCardPanel : MonoBehaviour
    {
        [SerializeField] private Text _abilityNameText;
        [SerializeField] private Text _abilityDescriptionText;
        [SerializeField] private Button _selectAbilityButton;

        private AbilityId cardAbility;

        private void OnEnable()
        {
            _selectAbilityButton?.onClick.AddListener(OnAbilityCardClicked);
        }
        
        private void OnDisable()
        {
            _selectAbilityButton?.onClick.RemoveListener(OnAbilityCardClicked);
        }

        public void Setup()
        {
            
        }

        private void OnAbilityCardClicked()
        {
            //TODO: Add the ability to the Hero Abilities class.
        }
    }
}