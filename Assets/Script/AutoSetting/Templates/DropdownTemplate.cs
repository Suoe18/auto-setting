using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace AutoSetting
{
    public class DropdownTemplate : ASettingConfigUI
    {
        [SerializeField]
        TMP_Dropdown dropdown;
        [SerializeField]
        TMP_Text settingConfigText; 

        public override ASettingConfigUI Render(Transform container, SettingConfig config)
        {  
            GameObject instance = Instantiate(gameObject, container);
            var component = instance.GetComponent<DropdownTemplate>();
            
            List<string> dropdown_options = new List<string> { };      

            if(config.Arguments != null)
            {
                foreach (var option in config.Arguments)
                {
                    dropdown_options.Add(option);
                } 

                component.dropdown.AddOptions(dropdown_options);
            }
            
            component.settingConfigText.text = config.Name;

            component.dropdown.onValueChanged.AddListener(index =>
            {
                config.OnUpdateValue(config.Arguments[index]);
            });

            config.OnSetValue += e =>
            { 
                component.dropdown.value = int.Parse(e.ToString());
                component.dropdown.RefreshShownValue();
            };

            config.OnGetValue += () => config.Arguments[component.dropdown.value];

            return component;
        }

        
    }
}

