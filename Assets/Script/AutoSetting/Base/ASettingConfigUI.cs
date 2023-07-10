using System;
using UnityEngine;

namespace AutoSetting
{
    public abstract class ASettingConfigUI : MonoBehaviour, ISettingConfigUI
    { 
        [SerializeField]
        ConfigType configType;
         
        public ConfigType ConfigType
        {
            get => configType;
            set => configType = value;
        }  
        public abstract ASettingConfigUI Render(Transform container, SettingConfig config);
    }
}





