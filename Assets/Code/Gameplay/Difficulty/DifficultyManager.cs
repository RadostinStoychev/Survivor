using Code.Gameplay.Characters.Enemies.Services;
using Code.Infrastructure.ConfigsManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Difficulty
{
    public class DifficultyManager : MonoBehaviour
    {
        private IEnemyFactory _enemyFactory;

        private DifficultyConfig _difficultyConfig;
        private float _difficultyIncreaseTimer = 0f;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory, IConfigsService configsService)
        {
            _enemyFactory = enemyFactory;
            _difficultyConfig = configsService.DifficultyConfig;
        }
        
        private void Update()
        {
            TryToIncreaseDifficulty();
        }

        private void TryToIncreaseDifficulty()
        {
            _difficultyIncreaseTimer += Time.deltaTime;

            if (_difficultyIncreaseTimer >= _difficultyConfig.DifficultyIncreaseTimeInterval)
            {
                _difficultyIncreaseTimer = 0f;
                _enemyFactory.UpdateEnemyDifficultyModifiers(_difficultyConfig.EnemyHealthIncreaseRate, _difficultyConfig.EnemyDamageIncreaseRate);
            }
        }
    }
}