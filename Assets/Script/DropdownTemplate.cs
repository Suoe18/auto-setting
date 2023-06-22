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

        public override void Render(Transform container, SettingConfig config)
        {
            List<string> dropdown_options = new List<string> { };
            GameObject instanceText = Instantiate(settingConfigText.gameObject, container);
            GameObject instance = Instantiate(dropdown.gameObject, container);

            var component = instance.GetComponent<TMP_Dropdown>();
            var componentText = instanceText.GetComponent<TMP_Text>();

            if(config.Arguments != null)
            {
                foreach (var option in config.Arguments)
                {
                    dropdown_options.Add(option);
                }


                component.AddOptions(dropdown_options);
            }
                        
            componentText.text = config.Name;
         
        }
    }
}

