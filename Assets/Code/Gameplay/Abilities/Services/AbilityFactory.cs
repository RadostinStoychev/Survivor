using Code.Gameplay.Abilities.Configs;
using Code.Infrastructure.ConfigsManagement;
using Code.Infrastructure.Instantiation;
using Code.UI;
using UnityEngine;

namespace Code.Gameplay.Abilities.Services
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IConfigsService _configsService;
        private readonly IInstantiateService _instantiateService;
        
        public AbilityFactory(IConfigsService configsService, IInstantiateService instantiateService)
        {
            _configsService = configsService;
            _instantiateService = instantiateService;
        }

        public bool CreateAbilityCard(AbilityId id, Transform parent, bool isAlreadyObtainedByHero)
        {
            AbilityConfig abilityConfig = _configsService.GetAbilityConfig(id);
            
            // Return early if hero already has a non-stackable ability.
            if (!abilityConfig.IsObtainableMoreThanOnce && isAlreadyObtainedByHero)
            {
                return false;
            }
            
            GameObject abilityCardObject = _instantiateService.InstantiatePrefabInParent(abilityConfig.Prefab, parent);
            abilityCardObject.GetComponent<AbilityCardPanel>().Setup(abilityConfig);

            return true;
        }
    }
}