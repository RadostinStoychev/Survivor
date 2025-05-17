using UnityEngine;

namespace Code.Gameplay.Abilities.Services
{
    public interface IAbilityFactory
    {
        bool CreateAbilityCard(AbilityId id, Transform parent, bool isAlreadyObtainedByHero);
    }
}