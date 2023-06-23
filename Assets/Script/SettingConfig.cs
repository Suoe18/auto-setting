using System;
using UnityEngine;

namespace AutoSetting
{
    [Serializable]
    public class SettingConfig
    {
        [SerializeField]
        string name;
        [SerializeField]
        ConfigType configType;
        [SerializeField]
        string value;
        
        public Action<object> OnValueUpdate;

        public string Name { get => name; set => name = value; }
        public ConfigType ConfigType { get => configType; set => configType = value; }
        public string Value { get => value; set => this.value = value; }
        public string ConfigID { get; internal set; }
        public string[] Arguments { get; internal set; }
    }
}





