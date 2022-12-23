using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostLand : MonoBehaviour
{
    public bool isLost = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isLost = true;
            Debug.Log("Da cham");
        }
    }
}
