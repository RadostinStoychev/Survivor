using Code.Gameplay.Cameras.Services;
using Code.Gameplay.Characters.Heroes.Behaviours;
using Code.Gameplay.Characters.Heroes.Services;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Infrastructure.Instantiation;
using Code.Infrastructure.UIManagement;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BattleInitializer : MonoBehaviour, IInitializable
	{
		[SerializeField] private Camera _mainCamera;
		[SerializeField] private Transform _uiRoot;

		private ICameraProvider _cameraProvider;
		private IHeroFactory _heroFactory;
		private IInstantiator _instantiator;
		private IInstantiateService _instantiateService;
		private IUIRootProvider _uiRootProvider;
		private IUiService _uiService;
		private Hero _activeHero;

		[Inject]
		private void Construct(
			ICameraProvider cameraProvider,
			IHeroFactory heroFactory,
			IInstantiateService instantiateService,
			IInstantiator instantiator,
			IUIRootProvider uiRootProvider,
			IUiService uiService
		)
		{
			_uiService = uiService;
			_uiRootProvider = uiRootProvider;
			_instantiateService = instantiateService;
			_instantiator = instantiator;
			_heroFactory = heroFactory;
			_cameraProvider = cameraProvider;
		}
    
		public void Initialize()
		{
			_cameraProvider.SetMainCamera(_mainCamera);
			_instantiateService.SetInstantiator(_instantiator);
			_uiRootProvider.SetUiRoot(_uiRoot);
			
			_activeHero = _heroFactory.CreateHero(Vector3.zero, Quaternion.identity);
			_activeHero.GetComponent<Experience>().OnLevelUp += () =>
			{
				_uiService.OpenWindowOverlay<LevelUpWindow>();
			};

			_uiService.OpenWindow<HudWindow>();
		}
	}
}