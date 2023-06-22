using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AutoSetting
{
    public class TextTemplate : ASettingConfigUI
    {
        [SerializeField]
        TMP_Text textTemplate;        
        [SerializeField]
        TMP_Text valueTextUI;

        public override void Render(Transform container, SettingConfig config)
        {
           
            GameObject textInstance = Instantiate(textTemplate.gameObject, container);
            GameObject valueTextInstance = Instantiate(valueTextUI.gameObject, container);

            var textComponent = textInstance.GetComponent<TMP_Text>();
            var valueComponent = valueTextInstance.GetComponent<TMP_Text>();


            textComponent.text = config.Name;
            valueComponent.text = config.Value;
        }
    
    }
}