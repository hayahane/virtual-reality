using Player.ItemList;
using UnityEngine;

namespace Interact
{
    public class PickableItem : MonoBehaviour, IInteractable
    {
        public int ItemId;

        public void InteractWith()
        {
            this.transform.position = PlayerItemList.Instance.transform.position +
                             PlayerItemList.Instance.transform.forward * 0.3f;
            this.gameObject.SetActive(false);
            PlayerItemList.Instance.AddItem(this);
        }
    }
}