using CharacterSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private GameInputAction _inputAction;
        private MovementController _movementController;
        
        [Inject]
        public void Construct(MovementController movementController)
        {
            _movementController = movementController;
            _inputAction = new();
            EnableInput();
        }
        
        private void Awake()
        {
            _inputAction.GlobalActionMap.MoveRight.started += MoveRight;
            _inputAction.GlobalActionMap.MoveLeft.started += MoveLeft;
            _inputAction.GlobalActionMap.Jump.started += Jump;
            _inputAction.GlobalActionMap.Slide.started += Slide;
        }

        public void EnableInput()
        {
            _inputAction.Enable();
        }
        
        public void DisableInput()
        {
            _inputAction.Disable();
        }
        
        private void MoveRight(InputAction.CallbackContext obj)
        {
            _movementController.MoveRight();
        }
        
        private void MoveLeft(InputAction.CallbackContext obj)
        {
            _movementController.MoveLeft();
        }
        
        private void Jump(InputAction.CallbackContext obj)
        {
            _movementController.Jump();
        }
        
        private void Slide(InputAction.CallbackContext obj)
        {
            _movementController.Slide();
        }
        
        private void OnDestroy()
        {
            DisableInput();
        }
    }
}
