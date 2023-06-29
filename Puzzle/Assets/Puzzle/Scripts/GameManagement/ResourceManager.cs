using Assets.Puzzle.Scripts.Extensions;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class ResourceManager : IResourceManager, ISystemResourceManager
    {
        public T GetAsset<T, E>(E item)
                where T : Object
                where E : Enum
        {
            var path = $"{typeof(E).Name}/{item.ToStringCached()}";
            var result = Resources.Load<T>(path);
            return result;
        }

        public T CreatePrefabInstance<T, E>(E item) where E : Enum
        {
            var prefab = CreatePrefabInstance(item);
            var result = prefab.GetComponent<T>();

            return result;
        }

        public GameObject CreatePrefabInstance<E>(E item) where E : Enum
        {
            var path = $"{typeof(E).Name}/{item?.ToStringCached()}";
            var asset = Resources.Load<GameObject>(path);
            var result = Object.Instantiate(asset);

            return result;
        }
    }
}
