using System;
using UnityEngine;

namespace AutoSetting
{
    [Serializable]
    public class SettingSection : AGroup<SettingConfig>
    {
  
        public SettingSection AddConfig(string config_id, string name, ConfigType configType, string firstvalue = "", string[] arguments = null)
        {
            var config = new SettingConfig();
            config.Name = name;
            config.ConfigType = configType;
            config.Value = firstvalue;
            config.ConfigID = config_id;
            config.Arguments = arguments;
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
}





