using UnityEngine;
using UniRx;
using TMPro;
using UnityEngine.Events;

public class BayItemScript : MonoBehaviour
{
    private ReactiveProperty<double> price;
    private ReactiveProperty<int> count;

    [SerializeField] TextMeshProUGUI priceTxt;
    [SerializeField] TextMeshProUGUI countTxt;
    [SerializeField] UnityEvent onClickEvent;
    [SerializeField] double initialPrice;
    [SerializeField] float itemPriceAcceleration = 1.5f;

    private void Start()
    {
        price = new ReactiveProperty<double>(initialPrice);
        price.Subscribe(v => priceTxt.text = $"{v:#,0} W");

        count = new ReactiveProperty<int>(0);
        count.Subscribe(v => countTxt.text = v.ToString());
    }

    public void OnPush()
    {
        if (Counter.num < price.Value) return;
        Counter.num -= price.Value;

        onClickEvent?.Invoke();

        price.Value = price.Value * itemPriceAcceleration;
        count.Value++;
    }
}
