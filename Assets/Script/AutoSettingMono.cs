using System.Collections.Generic;
using UnityEngine;

namespace AutoSetting
{
    public class AutoSettingMono : MonoBehaviour
    {
        public AutoSetting setting;        
        public List<GameObject> autoSettingsUI = new List<GameObject>();

        private void Awake()
        {           
            var option = setting.AddOption("graphics", "Graphics");
            option.AddSection("graphics", "Graphics")
                .AddConfig("1", "Resolution", ConfigType.DROPDOWN)
                .AddConfig("2", "FPS", ConfigType.DROPDOWN, "30 fps")
                .AddConfig("3", "VSync", ConfigType.DROPDOWN)
                .AddConfig("4", "Sensitivity", ConfigType.SLIDER);
        }
         
    }
}





