using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Collections.Specialized.BitVector32;
using System;
using UnityEngine.UI;

namespace AutoSetting
{
    public class AutoSettingMono : MonoBehaviour, IAutoSetting
    {
        public Transform containerOption;
        public Transform containerSubOptionGroup;

        public AutoSetting setting;
        public TabSystem tabSystem;
        public GameObject PrefabTitle;
        public GameObject PrefabSection;
        public GameObject PrefabSubOptionPanel;


        private void Onclintry()
        {

            for (int i = 0; i < tabSystem.tabButtons.Count; i++)
            {
                int index = i; // Capture the value of 'i' for the lambda expression
                tabSystem.tabButtons[i].onClick.AddListener(() => tabSystem.OnClick(index));
                tabSystem.tabButtons[i].onClick.AddListener(tabSystem.LogShow);
            }

            tabSystem.tabButtons[0].interactable = false;
            tabSystem.tabButtons[0].GetComponent<Image>().color = tabSystem.selectedColor;
            tabSystem.tabPanels[0].SetActive(true);

        }
        private void Awake()
        {

            AddGeneralSettingConfig();
            var controlOption = setting.AddOption("Control", "CONTROL");

            setting.Init(this);

        }
        private void AddGeneralSettingConfig()
        {
            var generalOption = setting.AddOption("General", "GENERAL");
            generalOption.AddSection("General", "GENERAL")
               .AddConfig("1", "Graphic Quality", ConfigType.DROPDOWN, "", new string[] { "Ultra", "High", "Medium", "Low" }, e =>
               {
                   Debug.Log("resolution value changed: " + e);
               })
               .AddConfig("2", "Frame Rate", ConfigType.DROPDOWN, "", new string[] { "60", "30", "15" }, e =>
               {
                   Debug.Log("fps value changed" + e);
                   //saving
               })
               .AddConfig("4", "Master Volume", ConfigType.SLIDER, "1")
               .AddConfig("5", "Sound FX Volume", ConfigType.SLIDER, "1")
               .AddConfig("6", "Music Volume", ConfigType.SLIDER, "1")
               .AddConfig("7", "VSYNC", ConfigType.TEXT, "ON");

            setting.UpdateSection("General", "GENERAL SETTING");
        }

        private void Start()
        {
            setting.Render();

            Debug.Log("initial: " + setting.GetConfigValue<string>("1"));
            setting.UpdateConfig("1", "1");
            setting.UpdateConfig("2", "1");


            Onclintry();
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
            instance.GetComponentInChildren<TMP_Text>().text = option.Name;


            tabSystem.tabButtons.Add(instance.GetComponent<Button>());
        }

        public Transform OnSubOptionLoadPanel(SettingOption option)
        {
            var instance = Instantiate(PrefabSubOptionPanel, containerSubOptionGroup);
            tabSystem.tabPanels.Add(instance);
            return instance.transform;
        }


    }
}





