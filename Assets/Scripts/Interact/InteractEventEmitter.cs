using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interact
{
    public class InteractEventEmitter : MonoBehaviour, IInteractable
    {
        public UnityEvent InteractEvent;
        
        void IInteractable.InteractWith()
        {
            InteractEvent.Invoke();
        }
    }
}