using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]

public abstract class BaseEnemy : MonoBehaviour
{
    protected Animator animator;
    protected Health enemyHealth;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<Health>();

        enemyHealth.OnHurt += EnemyAnimHurt;
        enemyHealth.OnDead += EnemyAnimDead;
    }

    protected virtual void EnemyAnimHurt()
    {
        animator.SetTrigger("Hurt");
    }

    protected virtual void EnemyAnimDead()
    {
        animator.SetTrigger("Dead");
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    protected abstract void Update();
}
