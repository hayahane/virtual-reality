## 简介
交互功能主要由 `Player` 物体上的 `InteractController` 控制

![InteractController.png](Assets%2FInteractController.png)
其余两项为引用设置，请使用 `InteractDistance` 控制可交互的距离

确保在添加下述组件前，为物体添加碰撞体组件，且 `IsCollider == false`

## 触发事件
为了方便修改和可视化的编辑，所有的组件都采用触发 `UnityEvent` 的方式进行（尽管这样的方法存在诸多其他短板，
但其可以可视化地触发和调整其他物体和脚本）。

## PickableItems
用于制作可以被捡起的物品。

请在 `HUD Canvas - Item List` 的 `ItemListController` 组件下设置物品和图标的查找表。
物品在数组中的序号将会对应其独特的 ItemId。

## InteractableItem
用于制作可以用特定物品互动的物品/机关。

设置 `RequiredItemId` 用于设置所需的特定物体。

## InteractableItemRepeat
用于制作多次交互的物体。

![InteractableItemRepeat.png](Assets%2FInteractableItemRepeat.png)
新增 `Interactions` 用于配置重复交互所需的次数以及触发的事件。

##InteractEventEmitter
用于更广范围的交互。

交互后会触发事件。

## 制作拼图游戏
使用 `PuzzleChecker` 组件。为每个拼图槽添加 `InteractableItem`组件，设置对应的拼图块。

将每个拼图槽的引用加入到 `PuzzleChecker` 的 PuzzlePieces 列表。 

## 拓展
只需要将新的组件脚本继承 `IInteractable` 并实现其中的 `InteractWith()` 函数即可。
例：
```csharp
namesapce Level
{
    public class Item : MonoBehaviour, IInteractable
    {
        /* Properties, fields and other methods */
        void IInteractable.InteractWith()
        {
            // Your code here
        }
    }
}
```