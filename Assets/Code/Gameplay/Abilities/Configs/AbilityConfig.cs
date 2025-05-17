using UnityEngine;

namespace Code.Gameplay.Abilities.Configs
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = Constants.GameName + "/Configs/Ability")]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId Id;

        public GameObject Prefab;
        
        public string Name;
        public string Description;
        public bool IsObtainableMoreThanOnce;
    }
}