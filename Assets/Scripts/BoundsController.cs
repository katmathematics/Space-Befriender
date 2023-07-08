using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsController : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private bool rightNext = true;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * - 1 + (objectHeight + 1), screenBounds.y - (objectHeight + 1));

        viewPos = CheckLayer(viewPos);

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * - 1 + (objectWidth + .5f), screenBounds.x - (objectWidth + .5f));
        
        transform.position = viewPos;
    }

    private Vector3 CheckLayer(Vector3 viewPos){
        if (rightNext && screenBounds.x - (objectWidth + .47f) <= viewPos.x) {
            viewPos.y = viewPos.y -1;
            rightNext = false;
        }
        else if (!rightNext && screenBounds.x * - 1 + (objectWidth + .47f) >= viewPos.x) {
            viewPos.y = viewPos.y - .2f;
            rightNext = true;
        }
        return viewPos;
    }
}
