using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textBoxMenu : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private TextMeshProUGUI textBoxText;

    private void Start()
    {
        sendTextToUI("ABC");

        textBox.SetActive(false);
    }

    public void sendTextToUI(string t)
    {
        textBox.SetActive(true);
        textBoxText.text = t;
    }
}
