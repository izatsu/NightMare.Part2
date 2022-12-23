using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDrop : MonoBehaviour
{
    [SerializeField] private GameObject thorn;
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            thorn.transform.position = Vector3.MoveTowards(thorn.transform.position, pos2.position, speed * Time.deltaTime);
            StartCoroutine(reset());
        }
    }

    private IEnumerator reset()
    {
        yield return new WaitForSeconds(3f);
        thorn.transform.position = pos1.position;
        Debug.Log("Da reset");
    }
}
