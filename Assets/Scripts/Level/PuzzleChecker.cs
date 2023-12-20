using System;
using System.Collections.Generic;
using Interact;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class PuzzleChecker : MonoBehaviour
    {
        [SerializeField] private List<InteractableItem> _puzzlePieces;
        public UnityEvent OnPuzzleFinished;

        public void Update()
        {
            var puzzleCheck = true;
            foreach (var piece in _puzzlePieces)
            {
                if (piece.enabled) puzzleCheck = false;
            }

            if (puzzleCheck)
            {
                OnPuzzleFinished?.Invoke();
                this.enabled = false;
            }
        }
    }
}