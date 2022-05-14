using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(StopActive());
    }

    IEnumerator StopActive()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
