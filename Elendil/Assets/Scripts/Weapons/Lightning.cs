using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightning : MonoBehaviour
{
    [SerializeField] private GameObject arcPrefab;
    [SerializeField] private float castRange = 700f;
    [SerializeField] private int bounces = 5;
    [SerializeField] private float bounceRange = 500f;
    [SerializeField] private float damage = 85f;
    [SerializeField] private float arcDelay = 0.2f;

    private Transform target;
    private List<Transform> hitTargets = new List<Transform>();

    public void Cast(Transform target)
    {
        this.target = target;
        StartCoroutine(CastArcLightning());
    }

    private IEnumerator CastArcLightning()
    {
        hitTargets.Clear();
        Transform currentTarget = target;
        hitTargets.Add(currentTarget);

        for (int i = 0; i < bounces; i++)
        {
            GameObject arc = Instantiate(arcPrefab, transform.position, Quaternion.identity);
            // Arc arcComponent = arc.GetComponent<Arc>();
            // if (arcComponent != null)
            // {
            //     arcComponent.StartArc(currentTarget);
            // }

            DealDamage(currentTarget);

            Transform nextTarget = FindNextTarget(currentTarget);
            if (nextTarget == null)
            {
                break;
            }

            currentTarget = nextTarget;
            hitTargets.Add(currentTarget);

            yield return new WaitForSeconds(arcDelay);
        }
    }

    private void DealDamage(Transform target)
    {
        // Implement your own method to apply damage to the target
    }

    private Transform FindNextTarget(Transform currentTarget)
    {
        Collider[] colliders = Physics.OverlapSphere(currentTarget.position, bounceRange);
        float shortestDistance = Mathf.Infinity;
        Transform nextTarget = null;

        foreach (Collider collider in colliders)
        {
            if (collider.transform == currentTarget || hitTargets.Contains(collider.transform))
            {
                continue;
            }

            float distanceToTarget = Vector3.Distance(currentTarget.position, collider.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nextTarget = collider.transform;
            }
        }

        return nextTarget;
    }
}