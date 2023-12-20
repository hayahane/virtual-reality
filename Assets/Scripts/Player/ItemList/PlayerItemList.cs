using System;
using System.Collections.Generic;
using System.Linq;
using Interact;
using Monologist.Patterns.Singleton;
using UI;
using UnityEngine;

namespace Player.ItemList
{
    public class PlayerItemList : Singleton<PlayerItemList>
    {
        [SerializeField]
        private ItemListController _listController;
        private readonly List<PickableItem> _itemList = new List<PickableItem>();
        private int _itemIndex;
        public PickableItem SelectedItem => _itemList[_itemIndex];

        public void AddItem(PickableItem item)
        {
            item.gameObject.SetActive(false);
            BuildItemListUI();
            _itemList.Add(item);
        }

        private void RemoveItem(PickableItem item)
        {
            _itemList.Remove(item);
            _itemIndex = Math.Clamp(_itemIndex,0,_itemList.Count);
            BuildItemListUI();
            Destroy(item);
        }

        public void RemoveSelected()
        {
            RemoveItem(SelectedItem);
        }

        public bool LookUpItem(String itemName, out PickableItem itemFound)
        {
            itemFound = _itemList.First(item => item.name == itemName);
            return itemFound != null;
        }

        private void BuildItemListUI()
        {
            for (int i = _itemIndex - 2; i <= _itemIndex + 2; i++)
            {
                if (i < 0 || i >= _itemList.Count) continue;
                _listController.SetItemUI(i - _itemIndex + 2, _itemList[i].ItemId);
            }
        }

        public void ChangeItem(SelectDirection direction)
        {
            if (!_listController.AnimationFinished) return;
            
            if (direction == SelectDirection.Left)
            {
                _itemIndex--;
                if (_itemIndex < 0) _itemIndex += _itemList.Count;
            }
            else
            {
                _itemIndex++;
                if (_itemIndex >= _itemList.Count) _itemIndex = 0;
            }

            _listController.ChangeItemSelected(direction);
            BuildItemListUI();
        }
    }
}