using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Puzzle.Scripts.Interfaces.GameMagagement
{
    public interface ISystemResourceManager
    {
        public T GetAsset<T, E>(E item)
           where T : Object
           where E : Enum;

        public T CreatePrefabInstance<T, E>(E item) where E : Enum;

        public GameObject CreatePrefabInstance<E>(E item) where E : Enum;
    }
}