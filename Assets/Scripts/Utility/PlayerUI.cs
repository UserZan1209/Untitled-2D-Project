using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject hpbar;
    [SerializeField] private Slider hpbarSlider;

    [SerializeField] private characterStatSystem playerStats;

    [HideInInspector] public int HP_VAL = 1;
    // Start is called before the first frame update
    void Start()
    {
        hpbarSlider = hpbar.transform.GetComponentInChildren<Slider>();
        playerStats = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<characterStatSystem>();
        //set parameters for hp bars
        hpbarSlider.maxValue = playerStats.returnHealthValue();
        hpbarSlider.value = playerStats.returnHealthValue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateHealthUI(int health)
    { 
        hpbarSlider.value = health;
    }
}
