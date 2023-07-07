using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Arcus
{ 
    public class NumericalSlider : MonoBehaviour
    {
        public TextMeshProUGUI numericalText;
        Slider mySlider;
        void Awake()
        {
            numericalText = transform.GetChild(transform.childCount - 1).GetComponent<TextMeshProUGUI>();
            mySlider = gameObject.GetComponent<Slider>();
            mySlider.onValueChanged.AddListener(delegate { onValueChange(); });
        }

        private void Start()
        {
            onValueChange();
        }
        public void onValueChange()
        {
            float range = mySlider.maxValue - mySlider.minValue;
            float translatedValue = mySlider.value - mySlider.minValue;
            float percentage = range != 0 ? translatedValue / range : 0;
            numericalText.text = Mathf.Round(percentage * 100).ToString() + "%";
        }
    }
}
