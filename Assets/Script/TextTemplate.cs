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
        GameObject textTemplatePrefab;

        TMP_Text nameTextUI;                
        TMP_Text valueTextUI;

        public override void Render(Transform container, SettingConfig config)
        {
           
            GameObject instance = Instantiate(textTemplatePrefab.gameObject, container);

            TMP_Text[] textComponents = instance.GetComponentsInChildren<TMP_Text>();
            foreach (TMP_Text textComponent in textComponents)
            {
                if (textComponent.gameObject.name.Equals("Name"))
                {
                    nameTextUI = textComponent;
                }
                else if (textComponent.gameObject.name.Equals("Value"))
                {
                    valueTextUI = textComponent;
                }
            }

            // Set the text values
            nameTextUI.text = config.Name;
            valueTextUI.text = config.Value;
        }
    
    }
}