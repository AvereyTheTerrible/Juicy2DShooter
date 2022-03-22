using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRegular : Bullet
{
    [SerializeField]
    protected Rigidbody2D rigidBody;
    protected bool isDead = false;
    public override SOBulletData BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            if (!rigidBody)
                rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidBody != null && BulletData != null)
            rigidBody.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!BulletData.GoThroughHittable)
        {
            if (isDead)
                return;
            isDead = true;
        }

        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(collision);
        }
        if (!BulletData.GoThroughHittable)
        {
            Destroy(gameObject);
        }
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
