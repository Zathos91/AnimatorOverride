using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;

    Vector2 movementDir;

    [SerializeField]
    bool isPlayer2 = false;

    [SerializeField]
    AnimatorOverrideController animOverride;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (isPlayer2)
            anim.runtimeAnimatorController = animOverride;
    }

    void Update()
    {
        if (isPlayer2)
        {
            GetInputPlayer2();
        }
        else
        {
            GetInputPlayer1();
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }


    void GetInputPlayer1()
    {
        float xAxis = Input.GetAxis("Horizontal");
        movementDir = new Vector2(xAxis, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
        {
            anim.SetTrigger("Attack");
        }
    }

    void GetInputPlayer2()
    {
        float xAxis = Input.GetAxis("HorizontalPlayer2");
        movementDir = new Vector2(xAxis, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.KeypadEnter)
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
        {
            anim.SetTrigger("Attack");
        }
    }

    void ApplyMovement()
    {
        body.velocity = movementDir * 3f;
        anim.SetFloat("Velocity", body.velocity.magnitude);
        if (movementDir.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f);
        }
        else if (movementDir.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f);
        }
    }
}
