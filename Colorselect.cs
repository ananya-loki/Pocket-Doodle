using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorselect : MonoBehaviour
{
    public static int colorval = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {

        colorval = 1;
        Debug.Log(colorval);
    }
}
