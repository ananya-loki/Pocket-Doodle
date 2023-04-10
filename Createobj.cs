using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createobj : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject reff;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown(){
    Debug.Log("Sprite Clicked");
    Instantiate(objectToSpawn, reff.transform.position, objectToSpawn.transform.rotation);
    }
}
