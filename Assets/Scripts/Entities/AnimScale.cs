using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation Scale", menuName = "Custom Assets/Animation/Scale")]

public class AnimScale : BaseAnims
{
    public override void Animate(Transform visual)
    {
        base.Animate(visual);
        visual.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo);
    }
}
