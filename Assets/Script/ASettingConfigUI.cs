using UnityEngine;

namespace AutoSetting
{
    public abstract class ASettingConfigUI : MonoBehaviour, ISettingConfigUI
    { 
        [SerializeField]
        ConfigType configType;

        [SerializeField]
        string renderValue;

        public ConfigType ConfigType
        {
            get => configType;
            set => configType = value;
        }

        public abstract void Render(Transform container, SettingConfig config);
    }
}





