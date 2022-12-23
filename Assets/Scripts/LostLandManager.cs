using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostLandManager : MonoBehaviour
{
    public LostLand ls;


    void Update()
    {
        if (ls.isLost == true)
        {
            StartCoroutine(Off());
            StartCoroutine(On());
        }


    }
    private IEnumerator On()
    {
        yield return new WaitForSeconds(2f);
        //ls.isLost = false;
        ls.gameObject.SetActive(true);
        Debug.Log("Da bat");
    }
    private IEnumerator Off()
    {
        yield return new WaitForSeconds(1f);
        ls.isLost = false;
        ls.gameObject.SetActive(false);
        Debug.Log("Da tat");
    }
}
