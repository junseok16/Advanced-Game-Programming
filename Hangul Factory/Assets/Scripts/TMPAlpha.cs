using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPAlpha : MonoBehaviour
{
    [SerializeField] private float lerpTime = 0.5f;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void fadeOut()
    {
        StartCoroutine(AlphaLerp(1, 0));
    }

    private IEnumerator AlphaLerp(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // lerpTime���� while �ݺ����� �����Ѵ�.
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            // Text; TextMeshPro�� ������ start���� end�� �����Ѵ�.
            Color color = text.color;
            color.a = Mathf.Lerp(start, end, percent);
            text.color = color;
            yield return null;
        }
    }
}
