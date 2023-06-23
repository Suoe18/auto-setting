using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AutoSetting
{
    public class SliderTemplate : ASettingConfigUI
    {
        [SerializeField]
        GameObject sliderTemplatePrefab;
        
        Slider slider;        
        TMP_Text settingConfigText;

        private float lastValue;
        private string namePlaceholder; 

        public override void Render(Transform parent, SettingConfig config)
        {
            GameObject instance = Instantiate(sliderTemplatePrefab.gameObject, parent);

            slider = instance.GetComponentInChildren<Slider>();
            settingConfigText = instance.GetComponentInChildren<TMP_Text>();

            slider.value = float.Parse(config.Value);
            settingConfigText.text = config.Name;

            slider.onValueChanged.AddListener(value =>
            {
                config.OnValueUpdate?.Invoke("value");  
            }); 

            namePlaceholder = config.Name;
            lastValue = slider.value;                     
            
        }

        public float GetLastValue()
        {
            return lastValue;
        }

        public string GetName()
        {
            return namePlaceholder;
        }
    }
}





