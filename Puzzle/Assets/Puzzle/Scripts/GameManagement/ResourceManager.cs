using Assets.BackToSchool.Scripts.Enums;
using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Extensions;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class ResourceManager : IResourceManager, ISystemResourceManager
    {
        public Camera CreateCamera()
        {
            var result = CreatePrefabInstance<Camera, EGame>(EGame.Camera);
            return result;
        }

        public IUIRoot CreateUIRoot(Camera worldSpaceCamera)
        {
            var result = CreatePrefabInstance<UIRoot, Eviews>(Eviews.UIRoot);
            result.Initialize(worldSpaceCamera);
            return result;
        }

        public T GetAsset<T>(string path)
                where T : Object
        {
            var result = Resources.Load<T>(path);
            return result;
        }

        public T[] GetAllAssets<T>(string path)
                 where T : Object
        {
            var result = Resources.LoadAll<T>(path);
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
