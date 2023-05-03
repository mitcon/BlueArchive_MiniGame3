using System.Collections;
using UnityEngine;
using DG.Tweening;

public class MessageBoxScript : MonoBehaviour
{
    [SerializeField] private float ShowTime = 1f;
    [SerializeField] private float FadeInDuration = 1f;
    [SerializeField] private float FadeOutDuration = 1f;
    [SerializeField] private float moveDistance = 10f;

    private RectTransform rect;
    private CanvasGroup cg;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();

        cg.alpha = 0f;
        StartCoroutine(ShowAnimationCol());
    }

    /// <summary>
    /// 表示非表示コルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowAnimationCol()
    {
        float startY = transform.localPosition.y;

        // 表示
        rect.DOAnchorPosY(startY + moveDistance, FadeInDuration);
        cg.DOFade(1f, FadeInDuration);
        yield return new WaitForSeconds(FadeInDuration + ShowTime);

        // 非表示
        rect.DOAnchorPosY(startY + moveDistance * 2, FadeOutDuration);
        cg.DOFade(0f, FadeOutDuration);
        yield return new WaitForSeconds(FadeOutDuration);
    }
}
