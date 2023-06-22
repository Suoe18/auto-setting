using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AutoSetting
{
    public class SliderTemplate : ASettingConfigUI
    {
        [SerializeField]
        Slider slider;

        [SerializeField]
        TMP_Text settingConfigText;

        private float lastValue;
        private string namePlaceholder;

        public event Func<float, float> OnSliderValueChanged;

        public override void Render(Transform parent, SettingConfig config)
        {
            GameObject instanceText = Instantiate(settingConfigText.gameObject, parent);
            GameObject instance = Instantiate(slider.gameObject, parent);

            var component = instance.GetComponent<Slider>();
            var componentText = instanceText.GetComponent<TMP_Text>();

            component.value = float.Parse(config.Value);
            componentText.text = config.Name;

         
            component.onValueChanged.AddListener(value =>
            {                
                float newValue = OnSliderValueChanged?.Invoke(value) ?? value;
                component.value = newValue;

                lastValue = newValue;
            });

            namePlaceholder = config.Name;
            lastValue = component.value;
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





