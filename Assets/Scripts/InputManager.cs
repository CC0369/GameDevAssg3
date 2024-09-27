using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEditor.Progress;

public class InputManager : MonoBehaviour
{
    public float moveSpeed = 0.00000001f;
    private Animator animator;
    private AudioSource audioSource;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        bool isMoving = false;

        animator.ResetTrigger("Up");
        animator.ResetTrigger("Down");
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Right");

        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            movement += Vector3.left;
            animator.SetTrigger("Left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            movement += Vector3.right;
            animator.SetTrigger("Right");
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            movement += Vector3.down;
            animator.SetTrigger("Down");
        }
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            movement += Vector3.up;
            animator.SetTrigger("Up");
        }
        transform.position += movement * (moveSpeed * 0.1f) * Time.deltaTime;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            animator.SetTrigger("Idle");
        }
    }
}
