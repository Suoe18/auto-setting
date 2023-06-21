using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using static UnityEditor.Progress;

namespace AutoSetting
{

    [Serializable]
    public class AutoSetting
    {
        public Transform container;

        [SerializeField]
        List<SettingOption> options = new List<SettingOption>();
        [SerializeField]
        List<ASettingConfigUI> configUITemplates = new List<ASettingConfigUI>();
        

        public void Init(List<SettingOption> setting)
        {

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
            foreach(var sections in item.List)
            {
                RenderSections(sections);
            }
        }

        private void RenderSections(SettingSection sections)
        {
            foreach(var config in sections.List)
            {
                RenderConfig(config);
            }
        }

        private void RenderConfig(SettingConfig config)
        {
            foreach(var config_template in configUITemplates)
            {
                if (config_template.ConfigType != config.ConfigType) continue;

                //TODO: render ui template
                Transform uiContainer = container;
                config_template.Render(uiContainer, config);
            }
        }
    }

    [Serializable]
    public class SettingOption : AGroup<SettingSection>
    {
        public SettingSection AddSection(string section_id, string section_name)
        {
            var section = new SettingSection();
            section.GroupId = section_id;
            section.Name = section_name;
            List.Add(section);

            return section;
        }
         

    }

    [Serializable]
    public class SettingSection : AGroup<SettingConfig>
    {
  
        public SettingSection AddConfig(string config_id, string name, ConfigType configType, string value = "")
        {
            var config = new SettingConfig();
            config.Name = name;
            config.ConfigType = configType;
            config.Value = value;
            config.ConfigID = config_id;
            List.Add(config);

            return this;
        }

        public SettingSection UpdateConfigValue(string config_id, string value)
        {            
            var config = List.Find(e => e.ConfigID.Equals(config_id));

            if (config != null)
            {
                config.Value = value;
            }
            else
            {
                Debug.LogError($"Invalid config id {config_id}");
            }

            return this;
        }

    }    


    [Serializable]
    public abstract class AGroup<T>
    {
        [SerializeField]
        string group_id;
        [SerializeField]
        string name;
        [SerializeField]
        List<T> list = new List<T>();

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<T> List
        {
            get => list;
            set => list = value;
        }
        public string GroupId { get => group_id; set => group_id = value; }
    }

    public abstract class ASettingConfigUI : MonoBehaviour, ISettingConfigUI
    { 
        [SerializeField]
        ConfigType configType;

        [SerializeField]
        string renderValue;

        public ConfigType ConfigType
        {
            get => configType;
            set => configType = value;
        }

        public abstract void Render(Transform container, SettingConfig config);
    }
    

    [Serializable]
    public class SettingConfig
    {
        [SerializeField]
        string name;
        [SerializeField]
        ConfigType configType;
        [SerializeField]
        string value;

        public string Name { get => name; set => name = value; }
        public ConfigType ConfigType { get => configType; set => configType = value; }
        public string Value { get => value; set => this.value = value; }
        public string ConfigID { get; internal set; }
    }

    public enum ConfigType
    {
        SLIDER,
        DROPDOWN
    }
}





