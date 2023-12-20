using Interact;
using Player.ItemList;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        public Transform CameraTrans;
        public PlayerInput Input;
    
        public FirstPersonController Player;
        public InteractController Interact;
        public PlayerItemList ItemList;

        private void OnEnable()
        {
            Input.actions["Move"].performed += OnMoveInput;
            Input.actions["Move"].canceled += OnMoveInput;

            Input.actions["Interact"].performed += OnInteractInput;

            Input.actions["ChangeItem"].performed += OnChangeItemInput;
        }

        private void OnDisable()
        {
            Input.actions["Move"].performed -= OnMoveInput;
            Input.actions["Move"].canceled -= OnMoveInput;

            Input.actions["Interact"].performed -= OnInteractInput;

            Input.actions["ChangeItem"].performed -= OnChangeItemInput;
        }

        #region Input Callbacks

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                Player.MoveDirection = Vector3.zero;
                return;
            }

            Vector2 rawInput = context.ReadValue<Vector2>();
            Player.MoveDirection =
                Quaternion.Euler(0, CameraTrans.eulerAngles.y, 0) * new Vector3(rawInput.x, 0, rawInput.y);
        }

        private void OnInteractInput(InputAction.CallbackContext _)
        {
            Interact.Interact();
        }

        private void OnChangeItemInput(InputAction.CallbackContext context)
        {
            if (context.ReadValue<float>() > 0)
                ItemList.ChangeItem(SelectDirection.Right);
            else
                ItemList.ChangeItem(SelectDirection.Left);
        }
    
        #endregion
    }
}
