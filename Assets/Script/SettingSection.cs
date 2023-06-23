using System;
using UnityEngine;

namespace AutoSetting
{
    [Serializable]
    public class SettingSection : AGroup<SettingConfig>
    {  
        public SettingSection AddConfig(string config_id, string name, ConfigType configType, string firstvalue = "", string[] arguments = null, Action<object> on_value_update = null)
        {
            var config = new SettingConfig();
            config.Name = name;
            config.ConfigType = configType;
            config.Value = firstvalue;
            config.ConfigID = config_id;
            config.Arguments = arguments;
            config.OnValueUpdate = on_value_update;
            List.Add(config);

            return this;
        }       
    }    
}





