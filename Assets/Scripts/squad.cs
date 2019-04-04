using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    [SerializeField] private int m_ShootCount = 0;
    [SerializeField] private float m_ShootDelta = 1f;
    [SerializeField] private bullet m_BulletPrefab = null;
    [SerializeField] private Transform m_Transform;
    [SerializeField] private float m_ShooterRadiusThreshold;
    [SerializeField] private float m_TargetRadiusThreshold;
    [SerializeField] private float m_ValleyThreshold;

    private void Start()
    {
        Volley();
    }

    private void Volley()
    {
        StartCoroutine(VolleyCoroutine());
    }

    private IEnumerator VolleyCoroutine()
    {
        while (true)
        {
            yield return ShootCoroutine(m_ShootCount);
            yield return new WaitForSeconds(Random.Range(0, m_ValleyThreshold));
        }
    }

    private IEnumerator ShootCoroutine(int shootCount)
    {
        for (int i = 0; i < shootCount; i++)
        {
            var bullet = Instantiate(m_BulletPrefab);
            bullet.transform.position = transform.position + (Random.insideUnitSphere * m_ShooterRadiusThreshold);
            bullet.Shoot(m_Transform.position + (Random.insideUnitSphere * m_TargetRadiusThreshold));

            yield return new WaitForSeconds(Random.Range(0, m_ShootDelta));
        }
    }
}
