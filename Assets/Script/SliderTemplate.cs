using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutoSetting
{
    public class SliderTemplate : ASettingConfigUI
    {
        [SerializeField]
        Slider slider;

        public override void Render(Transform parent, SettingConfig config)
        {
            GameObject instance = Instantiate(slider.gameObject, parent);
            var component = instance.GetComponent<Slider>();

            component.value = int.Parse(config.Value);
        }
    }
}





