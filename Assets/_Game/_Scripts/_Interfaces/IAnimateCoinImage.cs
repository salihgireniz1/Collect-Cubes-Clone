using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public interface IAnimateCoinImage
{
    public Transform CollectedCoinsImage { get; }
    public Tween AnimationTween { get; }
    public float AnimationDuration { get; }
    public Ease Ease { get; }
    Tween SetAnimation(Transform image);
    void Animate(GameObject collectedCoinImage);
}
