using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using static UnityEditor.Progress;

namespace AutoSetting
{

    [Serializable]
    public class AutoSetting
    {  
        [SerializeField]
        List<SettingOption> options = new List<SettingOption>();
        [SerializeField]
        List<ASettingConfigUI> configUITemplates = new List<ASettingConfigUI>();

        IAutoSetting isetting;         

        public void Init(IAutoSetting isetting)
        {
            this.isetting = isetting;


            if(configUITemplates.Count == 0)
            {
                Debug.LogError("Unable to load config uis, no template provided");
            }


            //Baysik
            if(configUITemplates.GroupBy(x => x.ConfigType).Count() != configUITemplates.Count())
            {
                Debug.LogError("Duplicate config_type in Config UI Templates. Please ensure you only have one type for each template");
            }
        }

        public SettingOption AddOption(string group_id, string name)
        {
            var option = new SettingOption();
            option.Name = name;
            option.GroupId = group_id;
            options.Add(option);
            return option;
        }


        public void Render()
        {
            foreach(var item in options)
            { 
                RenderOptions(item);
            }
        }
         
        private void RenderOptions(SettingOption item)
        {
            item.subOptionPanel = isetting.OnSubOptionLoadPanel(item);
            isetting.OnOptionLoadTitle(item);
            
            foreach (var sections in item.List)
            {
                RenderSections(item.subOptionPanel, sections);
            }
        }

        private void RenderSections(Transform subOptionPanel, SettingSection section)
        {
            isetting.OnOptionLoadSectionTitle(subOptionPanel, section);
            foreach (var config in section.List)
            {
                RenderConfig(subOptionPanel,config);
            }
        }

        private void RenderConfig(Transform subOptionPanel, SettingConfig config)
        {
            foreach(var config_template in configUITemplates)
            {
                if (config_template.ConfigType != config.ConfigType) continue;
                config_template.Render(subOptionPanel, config);
            }
        }

        public void UpdateConfig(string config_id, string newValue)
        {
            foreach (var config in options.SelectMany(option => option.List).SelectMany(section => section.List))
            {
                if (config.ConfigID == config_id)
                {
                    config.Value = newValue;
                    return; 
                }
            }
            
            Debug.LogError("Config with ID " + config_id + " not found.");
        }

        public void UpdateSection(string group_id, string newName)
        {
            foreach(var section in options.SelectMany(section => section.List))
            {
                if (section.GroupId == group_id)
                {
                    section.Name = newName;
                    return;
                }
            }

            Debug.LogError("Config with ID " + group_id + " not found.");
        }
    }
   

}





