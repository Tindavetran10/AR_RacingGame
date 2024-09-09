using PROMETEO___Car_Controller.Scripts.Bases;
using UnityEngine;

namespace PROMETEO___Car_Controller.Scripts
{
    public class PlayerInputController : MonoBehaviour
    {
        private static PlayerInputController _instance;
        private ARController arController; // InputActions generated script
        private bool turnLeft, turnRight, accelerate, reverse;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else Destroy(gameObject);
        }

        private void Start() => DontDestroyOnLoad(gameObject);

        private void OnEnable()
        {
            if(arController == null)
            {
                arController = new ARController();
                arController.Player.TurnLeft.performed += _ => turnLeft = true;
                arController.Player.TurnRight.performed += _ => turnRight = true;
                arController.Player.Accelerate.performed += _ => accelerate = true;
                arController.Player.Reverse.performed += _ => reverse = true;
            }
            arController.Enable();
        }

        private void Update() => HandleAllInputs();

        private void HandleAllInputs()
        {
            HandleTurnLeft();
            HandleTurnRight();
            HandleAccelerate();
            HandleReverse();
        }
        
        private void HandleTurnLeft()
        {
            if (turnLeft)
            {
                turnLeft = false;
                PrometeoCarController.Instance.TurnLeft();
            }
        }
        private void HandleTurnRight()
        {
            if (turnRight)
            {
                turnRight = false;
                PrometeoCarController.Instance.TurnRight();
            }
        }
        private void HandleAccelerate()
        {
            if (accelerate)
            {
                accelerate = false;
                PrometeoCarController.Instance.GoForward();
            }
            
        }
        private void HandleReverse()
        {
            if (reverse)
            {
                reverse = false;
                PrometeoCarController.Instance.GoReverse();
            }
        }
    }
}
