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
        [SerializeField]
        List<SettingOption> options = new List<SettingOption>();

        

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

            //List.Find(FindConfig);

            config = List.Find(delegate(SettingConfig a)
            {
                return a.ConfigID.Equals(config_id);
            });

            //equivalent

            foreach (var e in List)
            {
                if (e.ConfigID.Equals(config_id))
                {
                    e.Value = value;
                }
            }

            //another alternative

            for(int i = 0; i < List.Count; i++)
            {
                if (List[i].ConfigID.Equals(config_id))
                {
                    List[i].Value = value;
                }
            }

           if (config != null)
           {
               config.Value = value;
           }else
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

    [Serializable]
    public abstract class ASettingConfigUI
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

        public void Render(string renderValue)
        {

        }
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





