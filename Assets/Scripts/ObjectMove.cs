using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;



public class ObjectMove : MonoBehaviour
{
    [SerializeField] private Transform Position1;
    [SerializeField] private Transform Position2;
    private Vector3 nextpoint;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (transform.position == Position1.position)
            nextpoint = Position2.position;
        if (transform.position == Position2.position)
            nextpoint = Position1.position;

        transform.position = Vector3.MoveTowards(transform.position, nextpoint, speed * Time.deltaTime);


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}