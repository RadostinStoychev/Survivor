using System;
using Code.Gameplay.Abilities;
using Code.Gameplay.Abilities.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class AbilityCardPanel : MonoBehaviour
    {
        public Action<AbilityId> OnAbilityObtained;
        
        [SerializeField] private TextMeshProUGUI _abilityNameText;
        [SerializeField] private TextMeshProUGUI _abilityDescriptionText;
        [SerializeField] private Button _selectAbilityButton;

        private AbilityId _cardAbility;

        private void OnEnable()
        {
            _selectAbilityButton?.onClick.AddListener(OnAbilityCardClicked);
        }
        
        private void OnDisable()
        {
            _selectAbilityButton?.onClick.RemoveListener(OnAbilityCardClicked);
        }

        public void Setup(AbilityConfig abilityConfig)
        {
            _cardAbility = abilityConfig.Id;
            _abilityNameText.text = abilityConfig.Name;
            _abilityDescriptionText.text = abilityConfig.Description;
        }

        private void OnAbilityCardClicked()
        {
            OnAbilityObtained?.Invoke(_cardAbility);
        }
    }
}