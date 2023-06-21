using UnityEngine;

namespace AutoSetting
{
    public interface ISettingConfigUI
    {
        ConfigType ConfigType { get; set; }

        void Render(Transform container, SettingConfig config);
    }
}