using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace PROMETEO___Car_Controller.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Camera arCamera;
        [SerializeField] private LayerMask layersToInclude;
        
        private GameObject carController;

        private void Awake()
        {
            EnhancedTouchSupport.Enable();
        }

        private void Update()
        {
            //var activeTouches = EnhancedTouchSupport.GetActiveTouches();
        }
    }
}
