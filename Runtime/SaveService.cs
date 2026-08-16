using System;
using UnityEngine;
using WendellLeao.ServiceLocator;

namespace WendellLeao.Save
{
    /// <summary>
    /// The SaveService provides the abstraction <see cref="ISaveService"/> to trigger save/load anywhere in the game.
    /// The actual serialization logic is delegated to the assigned <see cref="ISaveDataHandler"/>.
    /// <seealso cref="Locator"/>
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SaveService : MonoBehaviour, ISaveService
    {
        [SerializeField]
        private MonoBehaviour saveDataHandler;

        private ISaveDataHandler _saveDataHandler;

        public void SaveData()
        {
            _saveDataHandler.SaveData();
        }

        public void LoadData()
        {
            _saveDataHandler.LoadData();
        }

        private void Awake()
        {
            if (saveDataHandler is not ISaveDataHandler handler)
            {
                throw new InvalidOperationException($"'{nameof(saveDataHandler)}' must implement '{nameof(ISaveDataHandler)}'!");
            }

            _saveDataHandler = handler;

            Locator.Register<ISaveService>(this);
        }

        private void OnDestroy()
        {
            Locator.Unregister<ISaveService>();
        }
    }
}
