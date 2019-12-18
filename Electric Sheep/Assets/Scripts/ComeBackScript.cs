using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComeBackScript : MonoBehaviour
{

    [TextArea]
    public string m_text;
    [Range(0.01f, 0.1f)]
    public float m_characterInterval;

    private string m_partialText;
    private float m_cumulativeDeltaTime;

    private Text m_label;

    private void Awake()
    {
        m_label = GetComponent<Text>();

    }

    void Start()
    {
        m_text = "Welcome back my dear " + PlayerPrefs.GetString("playerName") + " !\n\n So let's check how " + PlayerPrefs.GetString("sheepName") + " the sheep is going ... \n \n" ;
        m_partialText = "";
        m_cumulativeDeltaTime = 0;
    }

    void Update()
    {
        m_cumulativeDeltaTime += Time.deltaTime;
        while (m_cumulativeDeltaTime >= m_characterInterval && m_partialText.Length < m_text.Length)
        {
            m_partialText += m_text[m_partialText.Length];
            m_cumulativeDeltaTime -= m_characterInterval;
        }

        m_label.text = m_partialText;
    }

}
