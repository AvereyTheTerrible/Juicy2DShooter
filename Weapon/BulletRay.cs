using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRay : Bullet
{
    private bool isDead = true;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private LayerMask raycastMask;

    public override SOBulletData BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
        }
    }



    private void Start()
    {
        if (!BulletData.GoThroughHittable)
        {
            if (isDead)
                return;
            isDead = true;
        }
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right, float.MaxValue, raycastMask);
        var hittable = raycast.collider.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        if (raycast.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(raycast.collider);


        }

        if (raycast.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(raycast.collider);
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, raycast.point);
        StartCoroutine(DisableLineRendererCoroutine());
    }

    private IEnumerator DisableLineRendererCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.16f);
        Destroy(gameObject);
    }

    protected void HitEnemy(Collider2D enemyCollider)
    {
        var knockBack = enemyCollider.GetComponent<IKnockBack>();
        knockBack?.KnockBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBackTime);
        Vector2 randomOffset =
            Random.insideUnitCircle * enemyCollider.transform.root.GetComponentInChildren<Enemy>().
            EnemyFeedbackData.
            ImpactSpawnOffset;

        Instantiate(enemyCollider.transform.root.GetComponentInChildren<Enemy>().
            EnemyFeedbackData.ImpactPrefab,
            enemyCollider.transform.position + (Vector3)randomOffset,
            Quaternion.identity);
    }

    protected void HitObstacle(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        if (hit.collider)
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
    }
}
