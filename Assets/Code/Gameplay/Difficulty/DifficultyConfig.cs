using UnityEngine;

namespace Code.Gameplay.Difficulty
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = Constants.GameName + "/Configs/Difficulty")]
    public class DifficultyConfig : ScriptableObject
    {
        public int EnemyHealthIncreaseRate;
        public int EnemyDamageIncreaseRate;
        public float DifficultyIncreaseTimeInterval;
    }
}