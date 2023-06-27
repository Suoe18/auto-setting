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
            var option = setting.AddOption("graphics", "Graphics");


            option.AddSection("graphics", "Graphics")
                .AddConfig("1", "Resolution", ConfigType.DROPDOWN, "", new string[] { "1920x1080", "1080x720" }, e =>
                {
                    Debug.Log("resolution value changed" + e);
                })
                .AddConfig("2", "FPS", ConfigType.DROPDOWN, "", new string[] { "120 fps", "60 fps", "30 fps" }, e =>
                {
                    Debug.Log("fps value changed" + e);
                    //saving
                })
                .AddConfig("6", "FPS", ConfigType.DROPDOWN, "", new string[] { "120 fps", "22360 fps", "30 fps" }, e =>
                {
                    Debug.Log("fps value changed" + e);
                    //saving
                }) 
                .AddConfig("4", "Sensitivity", ConfigType.SLIDER, "1");
             
            setting.UpdateSection("graphics", "Video and Resolution");


            setting.Init(this);



        }

        private void Start()
        {
            setting.Render();
             
            Debug.Log("initial: " + setting.GetConfigValue<string>("1"));
            setting.UpdateConfig("1", "1");
            setting.UpdateConfig("2", "1");
            setting.UpdateConfig("6", "1");
            setting.UpdateConfig("4", "0.5");
            Debug.Log($"after modification: {setting.GetConfigValue<string>("1")}");
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





