using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float currentPosX;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;


    /* [SerializeField] private float yOffset = 1f;
     [SerializeField] Transform player;*/

    void Start()
    {

    }


    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, currentPosY, transform.position.z), ref velocity, speed);

    }

    public void MovetoNewRoomX(Transform _newroom)
    {
        currentPosX = _newroom.position.x;
        currentPosY = transform.position.y;
        Debug.Log("da di chuyen" + currentPosX);
        
    }

    public void MovetoNewRoomY(Transform _newroom)
    {
        currentPosY = _newroom.position.y;
        currentPosX = transform.position.x;
        Debug.Log("da di chuyen");
    }
}
