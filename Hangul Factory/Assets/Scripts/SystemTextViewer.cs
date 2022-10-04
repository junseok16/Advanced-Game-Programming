using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum SystemType { Money = 0, Build }

public class SystemTextViewer : MonoBehaviour
{
    private TextMeshProUGUI textSystem;
    private TMPAlpha tmpAlpha;

    private void Awake()
    {
        textSystem = GetComponent<TextMeshProUGUI>();
        tmpAlpha = GetComponent<TMPAlpha>();
    }

    public void printText(SystemType type)
    {
        switch (type)
        {
            case SystemType.Money:
                textSystem.text = "Not enough coin!";
                break;
            case SystemType.Build:
                textSystem.text = "Can't build the factory!";
                break;
        }
        // 문자열이 점점 사라진다.
        tmpAlpha.fadeOut();
    }
}
