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
        TMP_Text nameTextUI;
        [SerializeField]
        TMP_Text valueTextUI;

        public override ASettingConfigUI Render(Transform container, SettingConfig config)
        {

            GameObject instance = Instantiate(gameObject, container);
            var component = instance.GetComponent<TextTemplate>();

            config.OnSetValue += value => component.valueTextUI.text = value.ToString();
            config.OnGetValue += () => component.valueTextUI.text;

            component.nameTextUI.text = config.Name;
            component.valueTextUI.text = config.Value.ToString();


            //TMP_Text[] textComponents = instance.GetComponentsInChildren<TMP_Text>();
            //foreach (TMP_Text textComponent in textComponents)
            //{
            //    if (textComponent.gameObject.name.Equals("Name"))
            //    {
            //        nameTextUI = textComponent;
            //    }
            //    else if (textComponent.gameObject.name.Equals("Value"))
            //    {
            //        valueTextUI = textComponent;
            //    }
            //}

            //config.OnGetValue += () => config.Value.ToString();

            //// Set the text values
            //nameTextUI.text = config.Name;
            //valueTextUI.text = config.Value.ToString();

            return component;
        }
    
    }
}