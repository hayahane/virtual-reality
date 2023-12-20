## 场景结构
```
- Main Camera
- Input Manager
- Player
- HUD Canvas
```
上述为关键的物体，都已被设置为预制体，直接拖拽进最终场景便可使用，若有问题，可以参照 `Playground.scene` 中的结构。
- **Main Camera** 包含主相机以及 UI 相机，相机控制已经由 `Virtual Camera` 完成设置，不需要额外的设置，只需要保证存在于场景中
- **Input Manager** 负责将玩家的输入传递到场景中的物体上
- **Player** 代表玩家的物体
- **HUD Canvas** 抬头现实的 UI

## 场景设置

- **静态场景** 请设置 LayerMask 为 `Ground` 否则检测地面将出现问题导致角色控制出现问题。
- **动态场景** 需要互动的物体请参照 `Interactables.md`