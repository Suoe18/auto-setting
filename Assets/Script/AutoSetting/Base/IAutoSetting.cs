using UnityEngine;

namespace AutoSetting
{
    public interface IAutoSetting
    {
        void OnOptionLoadTitle(SettingOption option);
        void OnOptionLoadSectionTitle(Transform subOptionPanel, SettingSection section);
        Transform OnSubOptionLoadPanel(SettingOption option);
    }
}





