using UnityEngine;

namespace AutoSetting
{
    public interface ISettingConfigUI
    {
        ConfigType ConfigType { get; set; } 
        ASettingConfigUI Render(Transform container, SettingConfig config);
    }
}