using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

        MoveEnemy();
    }

    void MoveEnemy()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            SetAnimatorFloat(0, direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            SetAnimatorFloat(direction, 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void SetAnimatorFloat(float x, float y)
    {
        animator.SetFloat("Move X", x);
        animator.SetFloat("Move Y", y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!broken)
        {
            return;
        }

        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            Fix();
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");

        if (smokeEffect != null && smokeEffect.isPlaying)
        {
            smokeEffect.Stop();
        }
    }
}
