using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
          
        }
    }
      

   

}
