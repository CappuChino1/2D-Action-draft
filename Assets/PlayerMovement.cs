using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource _audioSource;

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

            //ジャンプの効果音(上ボタンを押すと連続で音がなってしまう)
            _audioSource.Play();
            Debug.Log("Jumping");
            //Initantiate(_jumpSE);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("Crouch");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        //_audioResource.Play();
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
       // _PlayingEnd();
    }


    private void _PlayingEnd()//呼んだらプレイやー消えちゃう、、、
    {
        if(_audioSource.isPlaying) return; //isPlaying←再生中、再生し終えたらDestroyで削除
        Destroy(gameObject);
    }
}