using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoSetting
{
    [Serializable]
    public abstract class AGroup<T>
    {
        [SerializeField]
        string group_id;
        [SerializeField]
        string name;
        [SerializeField]
        List<T> list = new List<T>();

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<T> List
        {
            get => list;
            set => list = value;
        }
        public string GroupId { get => group_id; set => group_id = value; }
    }
}





