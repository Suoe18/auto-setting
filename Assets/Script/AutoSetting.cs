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

        bool HasRendered { get; set; }

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
            HasRendered = true;
            foreach (var item in options)
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

        public T GetConfigValue<T>(string config_id)
        {
            if (!HasRendered) throw new Exception("AutoSettings is yet to be rendered. Please ensure you have rendered the object.");
            var config = options.SelectMany(option => option.List)
                .SelectMany(section => section.List)
                .Where(e => e.ConfigID == config_id).FirstOrDefault();

            if (config == null)
            {
                Debug.LogError($"Config ID: {config_id} does not exist in the list, please ensure your id exists.");
            }

            try
            {
                return (T)config?.OnGetValue();
            }catch(InvalidCastException ex)
            {
                Debug.LogError($"unable to cast config value of `{config.Value}` type of {typeof(T)}" + ex);
            }
            

            return default;
        } 

        public Transform GetSubOptionByGroupID(string group_id)
        {
            Transform id = options.Find(e => e.GroupId == group_id).subOptionPanel;


            if(id != null)
            {
                Debug.Log("Group ID: " + group_id);
            }
            else
            {
                Debug.LogError("Group ID: " + group_id + " not found.");
            }

            return id;
        }
    }
   

}





