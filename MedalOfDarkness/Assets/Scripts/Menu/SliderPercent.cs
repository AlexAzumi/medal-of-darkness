using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercent: MonoBehaviour 
{
    /* Made by Aldan Project | 2018 */

    /* Private stuff */
    private Text m_Text;

    private void Start()
    {
        m_Text = GetComponent<Text>();
    }

    public void volumeUpdate(float value)
    {
        m_Text.text = "Volumen: " + value + "%";
    }

    public void brightnessUpdate(float value)
    {
        m_Text.text = "Brillo: " + value + "%";
    }
}
