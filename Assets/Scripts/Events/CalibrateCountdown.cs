using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CalibrateCountdown : MonoBehaviour
{
    [SerializeField] int duration;
    public UnityEvent OnFinish = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    bool isCounting;

    public void StartCountdown()
    {
        if (isCounting == true)
        {
            StopAllCoroutines();
        }
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        isCounting = true;
        for (int i = duration; i >= 0; i--)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        isCounting = false;
        OnFinish.Invoke();
    }

    /* public void StartCountdown()
    {
        if (isCounting == true)
            return;
        else
            isCounting = true;
        var seq = DOTween.Sequence();
        int durInt = Mathf.FloorToInt(duration);
        OnCount.Invoke(durInt);
        for (int i = durInt - 1; i >= 0; i--)
        {
            seq.Append(transform
                .DOMove(this.transform.position, 1)
                .SetUpdate(true)
                .OnComplete(() => OnCount.Invoke(i)));
        }
        seq.Append(transform
            .DOMove(this.transform.position, 1)
            .SetUpdate(true)
            .OnComplete(() => OnFinish.Invoke()));
    } */
}
