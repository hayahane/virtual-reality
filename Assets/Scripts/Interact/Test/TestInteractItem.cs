using UnityEngine;

namespace Interact.Test
{
    public class TestInteractItem: MonoBehaviour, IInteractable
    {
        void IInteractable.InteractWith()
        {
            Debug.Log($"Interact With {name}");
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}