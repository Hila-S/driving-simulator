using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Globalization;

public class SwitchScenes : MonoBehaviour
{
    [SerializeField] GameObject dayController;
    Sun sun;

    public void ChangeScene(string scenesNames)
    {
        sun = dayController.GetComponent<Sun>();

        string[] namesOfScenes = scenesNames.Split(' '); 
        if (namesOfScenes.Length == 1)
        {
            SceneManager.LoadScene(namesOfScenes[0]);
        } else
        {
            string firstScene = namesOfScenes[0];
            string secondScene = namesOfScenes[1];

            if (firstScene == "DrivingSimulator" && secondScene == "NightSimulator")
            {
                DateTime date = DateTime.Now;
                string time = date.ToString().Split(' ')[1];
                TimeSpan timeSpan = TimeSpan.ParseExact(time, @"hh\:mm\:ss", CultureInfo.InvariantCulture);

                TimeSpan sunrise = sun.getSunriseTime();
                TimeSpan sunset = sun.getSunsetTime();

                DateTime summer_winter_2022 = new DateTime(2022, 10, 30, 2, 0, 0);
                DateTime summer_winter_2023 = new DateTime(2023, 10, 29, 2, 0, 0);
                DateTime summer_winter_2024 = new DateTime(2024, 10, 27, 2, 0, 0);
                DateTime winter_summer_2023 = new DateTime(2023, 3, 24, 2, 0, 0);
                DateTime winter_summer_2024 = new DateTime(2024, 3, 29, 2, 0, 0);

                TimeSpan sunriseIsrael = sunrise + TimeSpan.FromHours(2);
                TimeSpan sunsetIsrael = sunset + TimeSpan.FromHours(2);

                if (DateTime.Compare(date, summer_winter_2022) < 0 ||
                    (DateTime.Compare(date, winter_summer_2023) > 0 && DateTime.Compare(date, summer_winter_2023) < 0) ||
                    (DateTime.Compare(date, winter_summer_2024) > 0 && DateTime.Compare(date, summer_winter_2024) < 0))
                {
                    sunriseIsrael += TimeSpan.FromHours(1);
                    sunsetIsrael += TimeSpan.FromHours(1);
                }
                else if (DateTime.Compare(date, summer_winter_2024) >= 0)
                {
                    sunriseIsrael += TimeSpan.FromHours(1);
                    sunsetIsrael += TimeSpan.FromHours(1);
                }

                if (timeSpan > sunriseIsrael && timeSpan < sunsetIsrael)
                {
                    SceneManager.LoadScene(firstScene);
                }
                else
                {
                    SceneManager.LoadScene(secondScene);
                }
            }
        }
    }

}