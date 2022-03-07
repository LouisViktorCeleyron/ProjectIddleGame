using System;
using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{

    public float waitTime = 1;
    private void Start()
    {
        Debug.Log("Start de CoroutineTest");
        StartCoroutine(Attendre());

    }

    private void Update()
    {
        
    }

    public IEnumerator Attendre()
    {
        Debug.Log("Attendre s'est lancé");

        var i = 0;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Bonjour" + i.ToString());
            i++;
        }
    }
}
