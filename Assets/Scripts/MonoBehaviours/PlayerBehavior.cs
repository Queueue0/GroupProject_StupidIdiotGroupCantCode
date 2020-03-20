﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public Animator heart1Animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(new Vector3(Mathf.Clamp(transform.position.x + change.x * speed * Time.deltaTime, minPosition.x, maxPosition.x), 
                                            Mathf.Clamp(transform.position.y + change.y * speed * Time.deltaTime, minPosition.y, maxPosition.y)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float blend = heart1Animator.GetFloat("Blend");
        blend -= 0.5f;

        heart1Animator.SetFloat("Blend", blend);
    }
}
