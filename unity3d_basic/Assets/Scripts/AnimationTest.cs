using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTest : MonoBehaviour
{
    Animator animator;
    float speed;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            speed += Time.deltaTime;
            animator.SetFloat("Speed", speed);
        }
        else if(Input.GetKeyUp(KeyCode.T))
        {
            speed = 0;
        }
    }
}
