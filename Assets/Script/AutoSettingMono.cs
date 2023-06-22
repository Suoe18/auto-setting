using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Collections.Specialized.BitVector32;

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
            var option1 = setting.AddOption("audio", "Audio");
            var option = setting.AddOption("graphics", "Graphics");
            

            option.AddSection("graphics", "Graphics")
                .AddConfig("1", "Resolution", ConfigType.DROPDOWN, "1200x800")
                .AddConfig("2", "FPS", ConfigType.DROPDOWN, "60")
                .AddConfig("3", "VSync", ConfigType.DROPDOWN, "On")
                .AddConfig("4", "Sensitivity", ConfigType.SLIDER, "0.5");

            

            setting.Init(this);
        }

        private void Start()
        {
            setting.Render();
        }

        public void OnOptionLoadSectionTitle(Transform subOptionPanel, SettingSection section)
        {
            var instance = Instantiate(PrefabSection, subOptionPanel);
            instance.GetComponent<TMP_Text>().text = section.Name;
        }

        public void OnOptionLoadTitle(SettingOption option)
        {
            var instance = Instantiate(PrefabTitle, containerOption);
            instance.GetComponent<TMP_Text>().text = option.Name;
        }

        public Transform OnSubOptionLoadPanel(SettingOption option)
        {
            var instance = Instantiate(PrefabSubOptionPanel, containerSubOptionGroup);
            
            return instance.transform;
        }

        
         
    }
}





