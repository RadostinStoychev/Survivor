using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Abilities;
using Code.Gameplay.Abilities.Services;
using Code.Gameplay.Characters.Heroes.Behaviours;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Infrastructure.UIManagement;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class LevelUpWindow : WindowBase
    {
        private const int DisplayedAbilityCardsCount = 3;
        public override bool IsUserCanClose => false;

        [SerializeField] private Transform _abilityPanelsParent;
        
        private List<AbilityCardPanel> _abilityCards = new List<AbilityCardPanel>();
        
        private IAbilityFactory _abilityFactory;
        private IHeroProvider _heroProvider;
        
        [Inject]
        private void Construct(IAbilityFactory abilityFactory, IHeroProvider heroProvider)
        {
            _abilityFactory = abilityFactory;
            _heroProvider = heroProvider;
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            ToggleTimeFreeze();
            PrepareAbilityCards();
        }

        protected override void OnClose()
        {
            base.OnClose();
            ToggleTimeFreeze();
        }

        private void ToggleTimeFreeze()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        
        private void PrepareAbilityCards()
        {
            Hero hero = _heroProvider.Hero;
				
            if (hero == null)
                return;
            
            _abilityCards.Clear();

            int cardsCreated = 0;
            AbilityId[] allAbilityIds = (AbilityId[])Enum.GetValues(typeof(AbilityId));
            
            // Randomize the available abilities
            System.Random rng = new System.Random();
            AbilityId[] randomAbilityIds = Enum.GetValues(typeof(AbilityId))
                .Cast<AbilityId>()
                .OrderBy(_ => rng.Next())
                .Take(DisplayedAbilityCardsCount)
                .ToArray();

            foreach (AbilityId abilityId in randomAbilityIds)
            {
                bool isAbilityAlreadyObtainedByHero = IsAbilityAlreadyObtainedByHero(abilityId);

                AbilityCardPanel abilityCardPanel = _abilityFactory.CreateAbilityCard(abilityId, _abilityPanelsParent, isAbilityAlreadyObtainedByHero);
                if (abilityCardPanel != null)
                {
                    _abilityCards.Add(abilityCardPanel);
                    abilityCardPanel.OnAbilityObtained += OnAbilityObtainedByHero;
                    cardsCreated++;
                    
                    if (cardsCreated >= DisplayedAbilityCardsCount)
                        break;
                }
            }
        }

        private bool IsAbilityAlreadyObtainedByHero(AbilityId abilityId)
        {
            List<AbilityId> obtainedAbilityIds = _heroProvider.Abilities.GetHeroAbilities();
            return obtainedAbilityIds.Contains(abilityId);
        }

        private void OnAbilityObtainedByHero(AbilityId abilityId)
        {
            _heroProvider.Abilities.ObtainAbility(abilityId);
            
            foreach (AbilityCardPanel abilityCardPanel in _abilityCards)
            {
                abilityCardPanel.OnAbilityObtained -= OnAbilityObtainedByHero;
                Destroy(abilityCardPanel.gameObject);
            }
            
            CloseWindow();
        }
    }
}