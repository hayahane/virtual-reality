using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Player.ItemList;
using UnityEngine.UIElements;

namespace UI
{
    public enum SelectDirection
    {
        Left = -1,
        Right = 1
    }

    public class ItemListController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _itemListUi;
        [SerializeField] private RectTransform _context;
        [SerializeField] private List<Sprite> _itemTable;

        public float ChangeSpeed;
        public bool AnimationFinished { get; private set; } = true;

        public void SetItemUI(int index, int itemId)
        {
            _itemListUi[index].transform.GetChild(0).GetComponent<Image>().sprite
                = _itemTable[itemId];
        }
        
        public async void ChangeItemSelected(SelectDirection direction)
        {
            AnimationFinished = false;
            await MoveList(direction);
            if (direction == SelectDirection.Left)
                _context.transform.GetChild(0).SetSiblingIndex(_itemListUi.Length - 1);
            else
                _context.transform.GetChild(_itemListUi.Length - 1).SetSiblingIndex(0);
            _context.anchoredPosition = new Vector2(-240, 0);
            AnimationFinished = true;
        }

        private async Task MoveList(SelectDirection direction)
        {
            var moveDistance = 120f;
            while (moveDistance > 0)
            {
                var distance = Mathf.Max( 0.1f,moveDistance / 120f) * ChangeSpeed * Time.deltaTime;
                moveDistance -= distance;
                _context.anchoredPosition += (int)direction * distance * Vector2.right;
                await Task.Yield();
            }
        }
    }
}