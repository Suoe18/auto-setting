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
        GameObject dropdownTemplatePrefab;
        
        TMP_Dropdown dropdown;        
        TMP_Text settingConfigText; 

        public override void Render(Transform container, SettingConfig config)
        {            
            GameObject instance = Instantiate(dropdownTemplatePrefab.gameObject, container);

            List<string> dropdown_options = new List<string> { };
            dropdown = instance.GetComponentInChildren<TMP_Dropdown>();
            settingConfigText = instance.GetComponentInChildren<TMP_Text>();           

            if(config.Arguments != null)
            {
                foreach (var option in config.Arguments)
                {
                    dropdown_options.Add(option);
                }


                dropdown.AddOptions(dropdown_options);
            }
            
            settingConfigText.text = config.Name;

            dropdown.onValueChanged.AddListener(index =>
            {
                config.OnValueUpdate(config.Arguments[index]);
            });

            config.OnGetValue += () => config.Arguments[dropdown.value];
        }

        
    }
}

