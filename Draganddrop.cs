using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draganddrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private SpriteRenderer spriteRenderer;
    public Color newColor = Color.green;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnMouseDown()
    {
        if(Colorselect.colorval == 0)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        if(Colorselect.colorval == 1)
        {
            spriteRenderer.color = newColor;
            Colorselect.colorval = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}

