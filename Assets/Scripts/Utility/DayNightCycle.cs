using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] public GameObject mainLight;

    //light presets
    [SerializeField] public Color dayPreset;
    [SerializeField] public Color evePreset;
    [SerializeField] public Color nightPreset;

    [HideInInspector] private float time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dayNightCycle();
    }

    #region day-night functions
    private void dayNightCycle()
    {
        time += Time.deltaTime;
        //Debug.Log((int)time);

        switch ((int)time) 
        {
            case 10:
                SetLightPreset(0);
                break;
            case 20:
                SetLightPreset(1);
                break;
            case 30:
                SetLightPreset(2); 
                resetTime();
                break;
        }
    }

    private void resetTime()
    {
        time = 0; 
    }

    private void SetLightPreset(int i)
    {
        switch (i) 
        {
            case 0:
                mainLight.GetComponent<Light2D>().color = dayPreset;
                Debug.Log("err");
                break;
            case 1:
                mainLight.GetComponent<Light2D>().color = evePreset;
                break;
            case 2:
                mainLight.GetComponent<Light2D>().color = nightPreset;
                break;
        }

    }
    #endregion
}
