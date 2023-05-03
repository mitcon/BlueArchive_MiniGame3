using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HiyoriButtonScript : MonoBehaviour
{
    [SerializeField]
    AudioClip clickSound;

    [SerializeField]
    UnityEvent unityEvent;

    [SerializeField]
    float animationDuration = 1f;

    private AudioSource audioSource;
    private bool isClick = false;
    private float startY;

    void Start()
    {
        startY = transform.localPosition.y;
    }

    public void OnButtonClick()
    {
        Debug.Log($"click {gameObject.name}");
        //if (isClick) return;

        //クリック音を鳴らす
        SoundManager.PlaySe(clickSound);

        OnClickAnimation();

        //紐づけられた処理を実行する
        unityEvent?.Invoke();
    }

    private void OnClickAnimation()
    {
        StartCoroutine(onClickAnimationCol());
    }

    IEnumerator onClickAnimationCol()
    {
        float endY = startY - 5f;
        isClick = true;

        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.DOAnchorPosY(endY, animationDuration / 2f)
            .SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(animationDuration / 2f);

        rect.DOAnchorPosY(startY, animationDuration / 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => isClick = false);
    }
}
