using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GameSystem : MonoBehaviour
{
    public ReactiveProperty<int> senseiCount;
    public static int nezuCount = 0;
    public static int irohaCount = 0;
    public static int himariCount = 0;
    public static int arisuCount = 0;
    public static int utaCount = 0;

    [SerializeField] double hiyoriNum;
    [SerializeField] double nezuNum;
    [SerializeField] double irohaNum;
    [SerializeField] double himariNum;
    [SerializeField] double arisuNum;
    [SerializeField] double utaNum;

    private static IDisposable timer;

    private void Start()
    {
        InvokeRepeating(nameof(CulcPerSecondMethod), 0f, 1f);
        senseiCount = new ReactiveProperty<int>(0);
        senseiCount.Subscribe(num => senseiClickMethod(num));
    }

    /// <summary>
    /// １秒毎に増える値
    /// </summary>
    private void CulcPerSecondMethod()
    {
        double Value =
            nezuNum * nezuCount +
            irohaNum * irohaCount +
            himariNum * himariCount +
            arisuNum * arisuCount +
            utaNum * utaCount;

        Debug.Log($"{Value} W");
        Counter.num += Value;
        Counter.pers = Value;
    }

    public void OnHiyoriPush()
    {
        Counter.num += hiyoriNum;
    }

    public void OnSenseiPush()
    {
        senseiCount.Value++;
    }

    private void senseiClickMethod(int num)
    {
        if (timer != null)
            timer.Dispose();

        if (num == 0) return;

        timer = Observable.Interval(TimeSpan.FromSeconds(3f / num))
        .Subscribe(_ =>
        {
            Counter.num += hiyoriNum;
        });

        Counter.clickPers = hiyoriNum * (senseiCount.Value / 3f);
    }

    public void OnNezuPush()
    {
        nezuCount++;
    }

    public void OnIrohaPush()
    {
        irohaCount++;
    }

    public void OnHimariPush()
    {
        himariCount++;
    }

    public void OnArisuPush()
    {
        arisuCount++;
    }

    public void OnUtaPush()
    {
        utaCount++;
    }

}
