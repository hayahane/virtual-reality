using System;
using UI;
using UnityEngine;

namespace Interact
{
    public class InteractController : MonoBehaviour
    {
        public Transform CameraTrans;
        private IInteractable _interactItem;
        public CrossFireController CrossFire;
        public float InteractDistance = 1.8f;
        private void Update()
        {
            if (Physics.Raycast(CameraTrans.position + CameraTrans.forward, CameraTrans.forward, out var hitInfo,
                    InteractDistance))
            {
                _interactItem = hitInfo.collider.GetComponent<IInteractable>();
            }
            else _interactItem = null;
            
            if (_interactItem != null) CrossFire.SetCrossFire(CrossFireController.CrossFireStyle.Interact);
            else CrossFire.SetCrossFire(CrossFireController.CrossFireStyle.Normal);
        }

        public void Interact()
        {
            _interactItem?.InteractWith();
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(CameraTrans.position + CameraTrans.forward, CameraTrans.forward);
        }
#endif
    }
}