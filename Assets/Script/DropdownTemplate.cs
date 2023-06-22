using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

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
            List<string> m_DropOptions = new List<string> { };
            GameObject instanceText = Instantiate(settingConfigText.gameObject, container);
            GameObject instance = Instantiate(dropdown.gameObject, container);

            var component = instance.GetComponent<TMP_Dropdown>();
            var componentText = instanceText.GetComponent<TMP_Text>();

            m_DropOptions.Add(config.Value);

            component.AddOptions(m_DropOptions);
            
            componentText.text = config.Name;
        }
    }
}

