using System;
using Code.Gameplay.Characters.Enemies.Services;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.UnitStats;
using Code.Infrastructure.UIManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
	public class HudWindow : WindowBase
	{
		private const string ExperienceTextTemplate = "Experience: {0}";
		private const string LevelTextTemplate = "Lvl. {0}";
		
		[SerializeField] private Slider _healthBar;
		[SerializeField] private Slider _experienceBar;
		[SerializeField] private Text _currentExperienceText;
		[SerializeField] private Text _currentLevelText;
		[SerializeField] private Text _killedEnemiesText;
		
		private IHeroProvider _heroProvider;
		private IEnemyDeathTracker _enemyDeathTracker;

		public override bool IsUserCanClose => false;

		[Inject]
		private void Construct(IHeroProvider heroProvider, IEnemyDeathTracker enemyDeathTracker)
		{
			_enemyDeathTracker = enemyDeathTracker;
			_heroProvider = heroProvider;
		}

		protected override void OnUpdate()
		{
			UpdateHealthBar();
			UpdateExperienceBar();
			UpdateKilledEnemiesText();
			UpdateLevelText();
		}

		private void UpdateKilledEnemiesText()
		{
			_killedEnemiesText.text = _enemyDeathTracker.TotalKilledEnemies.ToString();
		}

		private void UpdateHealthBar()
		{
			if (_heroProvider.Hero != null)
				_healthBar.value = _heroProvider.Health.CurrentHealth / _heroProvider.Health.MaxHealth;
			else
				_healthBar.value = 0;
		}

		private void UpdateExperienceBar()
		{
			if (_heroProvider.Hero != null)
				_experienceBar.value = _heroProvider.Experience.CurrentExperience / _heroProvider.Experience.ExperienceToNextLevel;
			else
				_experienceBar.value = 0;

			var newExperienceValueString = _heroProvider.Experience.CurrentExperience + " / " + _heroProvider.Experience.ExperienceToNextLevel;
			_currentExperienceText.text = String.Format(ExperienceTextTemplate, newExperienceValueString);
		}

		private void UpdateLevelText()
		{
			_currentLevelText.text = String.Format(LevelTextTemplate, _heroProvider.Stats.GetStat(StatType.Level));
		}
	}
}