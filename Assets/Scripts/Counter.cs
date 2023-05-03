using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI persText;

    public static double num = 1000000;
    public static double pers = 0;
    public static double clickPers = 0;

    private void Update()
    {
        text.text = $"{num:#,0} W";
        persText.text = $"大体 {(pers + clickPers):#,0} W/s";
    }
}
