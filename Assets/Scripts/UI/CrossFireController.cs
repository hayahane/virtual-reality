using System;
using UnityEngine;

namespace UI
{
    public class CrossFireController : MonoBehaviour
    {
        public enum CrossFireStyle
        {
            Normal, Interact
        }
        
        [SerializeField] private GameObject[] _crossFires;
        private int _crossFireIndex = 0;

        private void OnEnable()
        {
            foreach (var o in _crossFires)
            {
                o.SetActive(false);
            }
            _crossFires[_crossFireIndex].SetActive(true);
        }

        public void SetCrossFire(CrossFireStyle style)
        {
            _crossFires[_crossFireIndex].SetActive(false);
            _crossFireIndex = (int)style;
            _crossFires[_crossFireIndex].SetActive(true);
        }
    }
}