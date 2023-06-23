using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Collections.Specialized.BitVector32;
using System;

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
            var option= setting.AddOption("graphics", "Graphics");


            option.AddSection("graphics", "Graphics")
                .AddConfig("1", "Resolution", ConfigType.DROPDOWN, "", new string[] { "1920x1080", "1080x720" }, e => {
                    Debug.Log("value changed" + e);
                })
                .AddConfig("2", "FPS", ConfigType.DROPDOWN, "", new string[] { "120 fps", "60 fps", "30 fps" })
                .AddConfig("3", "VSync", ConfigType.TEXT, "ON")
                .AddConfig("4", "Sensitivity", ConfigType.SLIDER, "1");

            setting.UpdateConfig("3", "OFF");
            setting.UpdateSection("graphics", "Video and Resolution");

            setting.Init(this);


            
        }

        private void Start()
        {
            setting.Render();

            Debug.Log("boom panes: " + setting.GetConfigValue<string>("3"));
            Debug.Log("boom panes: " + setting.GetConfigValue<string>("1"));
            Debug.Log("boom panes: " + setting.GetConfigValue<string>("4"));
            setting.GetSubOptionByGroupID("graphics");
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





