using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interact
{
    [Serializable]
    public class MultiInteraction
    {
        public int InteractTimes;
        public UnityEvent InteractEvent;
    }
    
    public class InteractableItemRepeat : MonoBehaviour, IInteractable
    {
        private int _interactTime;
        [SerializeField] private List<MultiInteraction> _interactions;
        void IInteractable.InteractWith()
        {
            _interactTime++;
            foreach (var interaction in _interactions)
            {
                if (interaction.InteractTimes == _interactTime)
                {
                    interaction.InteractEvent?.Invoke();
                }
            }
        }
    }
}