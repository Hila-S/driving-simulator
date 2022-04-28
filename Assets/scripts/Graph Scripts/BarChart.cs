using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BarChart : MonoBehaviour
{
    public Bar barPrefab;
    public int[] inputValues;
    public string[] labels;
    public Color[] colors;
    List<Bar> bars = new List<Bar>();
    float chartHeight;

    // Start is called before the first frame update
    void Start()
    {
        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y;
        DisplayGraph(inputValues);
    }

    void DisplayGraph(int[] vals)
    {
        int maxValue = vals.Max();
        for (int i = 0; i < vals.Length; i++)
        {
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform);
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            float normalizedValue = (float)vals[i] / (float)maxValue;
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
        }
        
    }

}
