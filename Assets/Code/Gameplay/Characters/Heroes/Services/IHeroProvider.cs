using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.UnitStats.Behaviours;

namespace Code.Gameplay.Characters.Heroes.Services
{
	public interface IHeroProvider
	{
		Behaviours.Hero Hero { get; }
		Health Health { get; }
		Experience Experience { get; }
		Stats Stats { get; }
		Abilities.Abilities Abilities { get; }
		void SetHero(Behaviours.Hero hero);
	}
}