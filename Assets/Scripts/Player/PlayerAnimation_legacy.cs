using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation_legacy : MonoBehaviour
{
    /*
	 * Walking
	 * Running
	 * Crouching
	 * AimingH
	 * AimingR
	 * Sooting  T
	 * Die      T
	 * Hit      T
	 * Jumping  T
	 */
    private Animator mAnimator;
    public int GunNum = 0;  //0:handgun  1:rifle 

    void Start()
    {
        mAnimator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        Shoot();
        Aim();
        Walk();
        Crouching();
        Jump();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !(mAnimator.GetBool("Running")) && !(mAnimator.GetBool("Walking")) && !(mAnimator.GetBool("Crouching")))
        {
            mAnimator.SetTrigger("Shooting");
        }
    }
    public void Aim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            switch (GunNum)
            {
                case 0:
                    mAnimator.SetBool("AimingH", true);
                    break;
                case 1:
                    mAnimator.SetBool("AimingR", true);
                    break;
                default:
                    break;
            }

        }
        else
        {
            mAnimator.SetBool("AimingH", false);
            mAnimator.SetBool("AimingR", false);

        }
    }
    public void Walk()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                mAnimator.SetBool("Running", true);
            }
            else
            {
                mAnimator.SetBool("Running", false);
                mAnimator.SetBool("Walking", true);
            }
        }
        else
        {
            mAnimator.SetBool("Running", false);
            mAnimator.SetBool("Walking", false);
        }
    }
    public void Crouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            mAnimator.SetTrigger("Crouch");
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            mAnimator.SetBool("Crouching", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            mAnimator.SetBool("Crouching", false);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mAnimator.SetTrigger("Jumping");
        }
    }
    public void Die()
    {
        mAnimator.SetTrigger("Die");
    }
    public void Hit()
    {
        mAnimator.SetTrigger("Hit");
    }

}
