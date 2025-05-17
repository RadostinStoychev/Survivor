using Code.UI;
using UnityEngine;

namespace Code.Gameplay.Abilities.Services
{
    public interface IAbilityFactory
    {
        AbilityCardPanel CreateAbilityCard(AbilityId id, Transform parent, bool isAlreadyObtainedByHero);
    }
}