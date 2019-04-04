using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed = 0f;

    public void Shoot(Vector3 targetPosition)
    {
        transform.DOMove(targetPosition, m_Speed).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }
}
