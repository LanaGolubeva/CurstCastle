using Cinemachine;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Inventory;
using StarterAssets.ThirdPersonController.Scripts;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IUIFactory _uiFactory;
        private readonly IInputService _inputService;
        private const string INPUT_SYSTEM_PATH = "InputSystem";
        private const string CHARACTER_PATH = "Character";
        private const string CAMERA_PATH = "CMvcam";


        public GameFactory(IUIFactory uiFactory, IInputService inputService)
        {
            _uiFactory = uiFactory;
            _inputService = inputService;
        }
        public GameObject CreateInputSystem()
        {
            GameObject pref = Resources.Load<GameObject>(INPUT_SYSTEM_PATH);
            return Object.Instantiate(pref);
        }

        public GameObject CreateCharacter()
        {
            GameObject pref = Resources.Load<GameObject>(CHARACTER_PATH);
            GameObject character = Object.Instantiate(pref);
            ThirdPersonController controller = character.GetComponent<ThirdPersonController>();
            controller.Construct(_inputService);

            PlayerRotation rotation = character.GetComponent<PlayerRotation>();
            rotation.Construct(_inputService.StarterAssetsInputs);

            InventoryService inventoryService = character.GetComponentInChildren<InventoryService>();
            inventoryService.Construct(_uiFactory);
            return character;
        }

        public void CreateVmCamera(GameObject target)
        {
            GameObject pref = Resources.Load<GameObject>(CAMERA_PATH);
            GameObject gameObject = Object.Instantiate(pref);
            CinemachineVirtualCamera vcamera = gameObject.GetComponent<CinemachineVirtualCamera>();
            vcamera.Follow = target.transform;
            vcamera.LookAt = target.transform;
        }
    }
}