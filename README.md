# Save Service

Attachable save/load service for Unity projects. Delegates serialization to a project-provided handler.

## Requirements

Add this dependency **first**, before installing this package. The Unity Package Manager does not resolve git-URL dependencies automatically, so skipping it will throw an exception at runtime:

- [WendellLeao.ServiceLocator](https://github.com/WendellLeao/service-locator.git)

## Installation

Add the package via the Unity Package Manager using a git URL:

```
https://github.com/WendellLeao/save-service.git
```

To pin a specific version, append `#v1.0.0` (or any tag) to the URL.

## Usage

`SaveService` is a concrete component: add it to a persistent GameObject in your startup scene and it registers itself as `ISaveService` right away. It does not know how to serialize your data. That logic is provided by your own component, implementing `ISaveDataHandler`:

```csharp
using UnityEngine;
using WendellLeao.Save;

public sealed class GameSaveDataHandler : MonoBehaviour, ISaveDataHandler
{
    public int HighScore;

    public void SaveData()
    {
        // write HighScore (and anything else) to disk however you like
    }

    public void LoadData()
    {
        // read it back
    }
}
```

1. Add `GameSaveDataHandler` (or your own equivalent) to the same GameObject as `SaveService`.
2. Drag it into the `SaveService`'s `Save Data Handler` field in the Inspector.
3. Trigger save/load through `ISaveService` from anywhere:

```csharp
using WendellLeao.Save;
using WendellLeao.ServiceLocator;

ISaveService saveService = Locator.Get<ISaveService>();

saveService.LoadData();

saveService.SaveData();
```

`SaveService` registers itself as `ISaveService` on `Awake` and unregisters on `OnDestroy`.
