using Player.ItemList;
using UnityEngine;
using UnityEngine.Events;

namespace Interact
{
    [RequireComponent(typeof(Collider))]
    public class InteractableItem : MonoBehaviour, IInteractable
    {
        public int RequiredItemId = -1;
        public UnityEvent OnInteracted;
        void IInteractable.InteractWith()
        {
            if (PlayerItemList.Instance.SelectedItem.ItemId != RequiredItemId) return;
            
            PlayerItemList.Instance.RemoveSelected();
            OnInteracted.Invoke();
            this.GetComponent<Collider>().enabled = false;
            this.enabled = false;
        }
    }
}