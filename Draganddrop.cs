using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draganddrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private SpriteRenderer spriteRenderer;
    public Color red = Color.red;
    public Color green = Color.green;
    public Color blue = Color.blue;
    public Color yellow = Color.yellow;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        Debug.Log(Colorselect.colorval);
        if(Colorselect.colorval == 0)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }


        if(Colorselect.colorval == 1)
        {
            spriteRenderer.color = red;
            Colorselect.colorval = 0;
        }


        if(Colorselect.colorval == 2)
        {
            spriteRenderer.color = green;
            Colorselect.colorval = 0;
        }


        if(Colorselect.colorval == 3)
        {
            spriteRenderer.color = blue;
            Colorselect.colorval = 0;
        }


        if(Colorselect.colorval == 4)
        {
            spriteRenderer.color = yellow;
            Colorselect.colorval = 0;
        }

    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

}
