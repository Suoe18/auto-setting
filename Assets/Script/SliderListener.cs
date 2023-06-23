using UnityEngine;

namespace AutoSetting
{
    public class SliderListener : MonoBehaviour
    {
        [SerializeField]
        private SliderTemplate sliderTemplate;

        private void OnEnable()
        {
            //sliderTemplate.OnSliderValueChanged += ConfigSliderValueChanged;
        }

        private void OnDisable()
        {
            //sliderTemplate.OnSliderValueChanged -= ConfigSliderValueChanged;
        }

        private float ConfigSliderValueChanged(float value)
        {
            float lastValue = sliderTemplate.GetLastValue();
            string name = sliderTemplate.GetName();

            Debug.Log($"{name} slider value changed from {lastValue} to {value}.");

            float modifiedValue = value;
                        
            return modifiedValue;
        }
    }
}





