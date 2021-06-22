using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;

    Vector2 movement = new Vector2();

    Rigidbody2D rb2D;

    Animator animator;
    string animationState = "AnimationState";

    enum CharactorState 
    {
        walkEast = 1,
        walkWest = 2,
        walkNorth = 3,
        walkSouth = 4,
        southIdle = 5
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        updateState();
    }

    private void updateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharactorState.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharactorState.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharactorState.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharactorState.walkSouth);
        } else animator.SetInteger(animationState, (int)CharactorState.southIdle);
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2D.velocity = movement * movementSpeed;
    }
}
