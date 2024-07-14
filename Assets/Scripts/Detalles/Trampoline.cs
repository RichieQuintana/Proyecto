using UnityEditor.VersionControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Trampoline : MonoBehaviour
{
    public float JumpForce = 15f;  // La fuerza del rebote
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * JumpForce);
            animator.Play("JumpTrampolin");        
        }
    }

}


