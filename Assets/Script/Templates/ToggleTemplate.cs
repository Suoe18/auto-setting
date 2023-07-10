using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace AutoSetting { 
public class ToggleTemplate : ASettingConfigUI
    {
        [SerializeField]
        Toggle toggle;
        [SerializeField]
        TMP_Text settingConfigText;

        public override ASettingConfigUI Render(Transform container, SettingConfig config)
        {
            GameObject instance = Instantiate(gameObject, container);
            var component = instance.GetComponent<ToggleTemplate>();

            component.settingConfigText.text = config.Name;

            component.toggle.onValueChanged.AddListener(isOn =>
            {
                //config.OnUpdateValue(config.Value(isOn));
                config.OnUpdateValue?.Invoke(isOn);
            });

            config.OnSetValue += e =>
            {
                component.toggle.isOn = Convert.ToBoolean(e);
            };

            config.OnGetValue += () => component.toggle.isOn;

            return component;
        }

    
  
}
}