using System.Collections.Generic;
using UnityEngine;

namespace AutoSetting
{
    public class AutoSettingMono : MonoBehaviour, IAutoSetting
    {
        public Transform containerOption;
        public Transform containerSubOptionGroup;

        public AutoSetting setting;        
        public List<GameObject> autoSettingsUI = new List<GameObject>();
        public GameObject PrefabTitle;
        public GameObject PrefabSection;
        public GameObject PrefabSubOptionPanel;

        private void Awake()
        {
            var option = setting.AddOption("graphics", "Graphics");

            option.AddSection("graphics", "Graphics")
                .AddConfig("1", "Resolution", ConfigType.SLIDER,"2")
                .AddConfig("2", "FPS", ConfigType.SLIDER, "30")
                .AddConfig("3", "VSync", ConfigType.SLIDER,"3")
                .AddConfig("4", "Sensitivity", ConfigType.SLIDER,"2");

            setting.Init(this);
        }

        private void Start()
        {
            setting.Render();
        }

        public void OnOptionLoadSectionTitle(Transform subOptionPanel, SettingSection section)
        {
            var instance = Instantiate(PrefabSection, subOptionPanel);
        }

        public void OnOptionLoadTitle(SettingOption option)
        {
            var instance = Instantiate(PrefabTitle, containerOption);
        }

        public Transform OnSubOptionLoadPanel(SettingOption option)
        {
            var instance = Instantiate(PrefabSubOptionPanel, containerSubOptionGroup);

            return instance.transform;
        }

        
         
    }
}





