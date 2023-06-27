using System;
using UnityEngine;
using static UnityEditor.Progress;

namespace AutoSetting
{
    [Serializable]
    public class SettingOption : AGroup<SettingSection>
    {
        public Transform subOptionPanel;
        public SettingSection AddSection(string section_id, string section_name)
        {
            var section = new SettingSection();
            section.GroupId = section_id;
            section.Name = section_name;
            List.Add(section);

            return section;
        }        
    }
}





