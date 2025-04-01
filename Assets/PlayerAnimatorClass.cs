using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorClass : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    private Animator anim;
    private bool isAttacking = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        if (isAttacking == false)
        {
            rigid.linearVelocity = movement * speed;
            anim.SetFloat("Movement", moveHorizontal);
        }
        else
        {
            anim.SetFloat("Movement", 0f);
        }
    }
}
