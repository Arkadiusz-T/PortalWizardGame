using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainOneObjectWithTag : MonoBehaviour
{
    public string tagToRemove;
    private GameObject[] objToRemove;
    // Start is called before the first frame update
    void Start()
    {
        objToRemove = GameObject.FindGameObjectsWithTag(tag);
        if(objToRemove.Length > 1) Destroy(objToRemove[0]);
    }
}
