using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayGraph : MonoBehaviour
{
    ToggleGroup toggleGroup;

    BarChart barChart;
    [SerializeField] GameObject chart;

    Toggle overall_toggle;
    Toggle directions_toggle;
    Toggle trafficSigns_toggle;
    Toggle pedestrians_toggle;
    Toggle trafficLight_toggle;
    Toggle speedLimit_toggle;
    Toggle collisions_toggle;
    Toggle lanes_toggle;

    int[] overall_values;
    int[] directions_values;
    int[] trafficSigns_values;
    int[] pedestrians_values;
    int[] trafficLight_values;
    int[] speedLimit_values;
    int[] collisions_values;
    int[] lanes_values;

    public Toggle currentSelection
    {
        get { return toggleGroup.ActiveToggles().FirstOrDefault(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        //Debug.Log("First Selected" + currentSelection.name);
        barChart = chart.GetComponent<BarChart>();

        overall_values = new int[] { 1, 3, 5, 7, 9, 11 };
        directions_values = new int[] { 2, 3, 7, 7, 9, 11 };
        trafficSigns_values = new int[] { 3, 3, 6, 7, 9, 11 };
        pedestrians_values = new int[] { 4, 3, 5, 7, 9, 11 };
        trafficLight_values = new int[] { 5, 3, 2, 7, 9, 11 };
        speedLimit_values = new int[] { 6, 3, 5, 1, 9, 11 };
        collisions_values = new int[] { 7, 3, 5, 7, 9, 11 };
        lanes_values = new int[] { 8, 3, 5, 7, 2, 11 };

        overall_toggle = transform.Find("Overall Errors").GetComponent<Toggle>();
        overall_toggle.onValueChanged.AddListener(delegate {
            if (overall_toggle.isOn)
            {
                displayGraph(overall_values);
            }
        });
        directions_toggle = transform.Find("Directions").GetComponent<Toggle>();
        directions_toggle.onValueChanged.AddListener(delegate {
            if (directions_toggle.isOn)
            {
                displayGraph(directions_values);
            }
        });
        trafficSigns_toggle = transform.Find("Traffic Signs").GetComponent<Toggle>();
        trafficSigns_toggle.onValueChanged.AddListener(delegate {
            if (trafficSigns_toggle.isOn)
            {
                displayGraph(trafficSigns_values);
            }
        });
        pedestrians_toggle = transform.Find("Pedestrians").GetComponent<Toggle>();
        pedestrians_toggle.onValueChanged.AddListener(delegate {
            if (pedestrians_toggle.isOn)
            {
                displayGraph(pedestrians_values);
            }
        });
        trafficLight_toggle = transform.Find("Traffic Lights").GetComponent<Toggle>();
        trafficLight_toggle.onValueChanged.AddListener(delegate {
            if (trafficLight_toggle.isOn)
            {
                displayGraph(trafficLight_values);
            }
        });
        speedLimit_toggle = transform.Find("Speed Limit").GetComponent<Toggle>();
        speedLimit_toggle.onValueChanged.AddListener(delegate {
            if (speedLimit_toggle.isOn)
            {
                displayGraph(speedLimit_values);
            }
        });
        collisions_toggle = transform.Find("Collisions").GetComponent<Toggle>();
        collisions_toggle.onValueChanged.AddListener(delegate {
            if (collisions_toggle.isOn)
            {
                displayGraph(collisions_values);
            }
        });
        lanes_toggle = transform.Find("Lanes").GetComponent<Toggle>();
        lanes_toggle.onValueChanged.AddListener(delegate {
            if (lanes_toggle.isOn)
            {
                displayGraph(lanes_values);
            }
        });

        displayGraph(overall_values);
    }

    public void displayGraph(int[] inputValues)
    {
        barChart.Clear();
        barChart.DisplayGraph(inputValues);
    }
}
