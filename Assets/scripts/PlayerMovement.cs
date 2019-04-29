using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    int UP = 0;
    int SIDE = 1;
    int DOWN = 2;
    public GameControl controller;

    [Header("Movement")]
    public float walkSpeed = 1f;

    public Animator animator;
    public bool IsDying;
    public bool isTalking;

    public Animator dialogueAnimator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        IsDying = false;
        isTalking = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsDying) return;
        isTalking = dialogueAnimator.GetBool("IsOpen");
        
        
    }

    private void FixedUpdate()
    {
        if (IsDying) return;
        if (!isTalking) {
            Move();
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }



    /*Uses translations to move the player*/
    void Move()
    {
        float movHor = Input.GetAxisRaw("Horizontal");
        float movVer = Input.GetAxisRaw("Vertical");
        
        if (movHor != 0 || movVer != 0)
        {
            animator.SetBool("IsMoving", true);
            transform.Translate(new Vector3(walkSpeed * Time.deltaTime * movHor, walkSpeed * Time.deltaTime * movVer, 0).normalized * 0.1f * walkSpeed);
            int direction = lookingDirection(movVer,movHor);
            animator.SetInteger("LookDirection", direction);
            if(direction == SIDE)
            {
                transform.localScale = new Vector3(((movHor > 0)? 1 : -1) * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    private int lookingDirection(float movVer, float movHor)
    {
        int res = 1;
        if(movVer < 0)
        {
            res = DOWN;
        }
        else if(movVer > 0 && Mathf.Abs(movHor) < movVer)
        {
            res = UP;
        }
        return res;
    }
}
