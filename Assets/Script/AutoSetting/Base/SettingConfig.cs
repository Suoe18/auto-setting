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

        object value;
        
        public Action<object> OnUpdateValue;
        public Func<object> OnGetValue;
        public Action<object> OnSetValue;
        

        public string Name { get => name; set => name = value; }
        public ConfigType ConfigType { get => configType; set => configType = value; }
        public object Value { 
            get
            {
                return value;
            }
            set => this.value = value; 
        }
        public string ConfigID { get; internal set; }
        public string[] Arguments { get; internal set; }

        public void ReflectChanges()
        { 
            OnSetValue?.Invoke(value);
        }
    }
}





