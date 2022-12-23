using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorY : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.y < transform.position.y)
                cam.MovetoNewRoomY(nextRoom);
            else if (collision.transform.position.y > transform.position.y)
                cam.MovetoNewRoomY(previousRoom);
        }
    }
}
