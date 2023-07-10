using System;
using TMPro;
using Unity.VisualScripting.FullSerializer;
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
         
        public override ASettingConfigUI Render(Transform container, SettingConfig config)
        {
            GameObject instance = Instantiate(gameObject, container);
            var sliderTemplate = instance.GetComponent<SliderTemplate>();

            config.OnSetValue += value => sliderTemplate.slider.value = float.Parse(value.ToString());
            config.OnGetValue += () => sliderTemplate.slider.value;

            sliderTemplate.slider.onValueChanged.AddListener(value =>
            {
                config.OnUpdateValue?.Invoke(sliderTemplate.slider.value);
            });

            sliderTemplate.settingConfigText.text = config.Name; 

            return sliderTemplate;
        } 
    }
}





