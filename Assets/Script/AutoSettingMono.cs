using UnityEngine;

namespace AutoSetting
{
    public class AutoSettingMono : MonoBehaviour
    {
        public AutoSetting setting;

        private void Awake()
        {
            var option = setting.AddOption("graphics", "Graphics");
            option.AddSection("graphics", "Graphics")
                .AddConfig("", "VSync", ConfigType.SLIDER, "MEMA")
                .AddConfig("", "VSync", ConfigType.SLIDER)
                .AddConfig("", "VSync", ConfigType.SLIDER)
                .AddConfig("", "VSync", ConfigType.SLIDER);

            option.AddSection("", "")
                .AddConfig("", "s", ConfigType.DROPDOWN)
                .AddConfig("", "s", ConfigType.DROPDOWN)
                .AddConfig("", "s", ConfigType.DROPDOWN)
                .AddConfig("", "s", ConfigType.DROPDOWN)
                .AddConfig("", "s", ConfigType.DROPDOWN);
        }
    }
}





