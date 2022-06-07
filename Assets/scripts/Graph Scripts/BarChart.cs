using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BarChart : MonoBehaviour
{
    public Bar barPrefab;
    public Color[] colors;
    string[] labels;
    List<Bar> bars = new List<Bar>();
    float chartHeight;

    // Start is called before the first frame update
    void Start()
    {
        labels = new string[]{ "", "", "", "", "", ""};
        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y;
    }

    public void DisplayGraph(int[] vals)
    {
        if (vals.Length > 1)
        {
            labels[0] = "Least Recent";
            labels[vals.Length - 1] = "Most Recent";
        }
        int maxValue = vals.Max();
        for (int i = 0; i < vals.Length; i++)
        {
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform);
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            float normalizedValue = (float)vals[i] / (float)maxValue;
            if (maxValue == 0)
                normalizedValue = 0;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHeight * normalizedValue);
            newBar.bar.color = colors[i % colors.Length];
            if (labels.Length <= i)
            {
                newBar.label.text = "UNDEFINED";
            }
            else
            {
                newBar.label.text = labels[i];
            }
            newBar.value.text = vals[i].ToString();
        }
    }

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}
