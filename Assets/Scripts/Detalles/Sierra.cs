using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")){
            Debug.Log("Player Dameged");
            Destroy(collision.gameObject);
        }
    }
}
