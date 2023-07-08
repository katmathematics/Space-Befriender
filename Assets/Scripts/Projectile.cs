using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public float moveSpeed = 2f;

    private Vector2 screenBounds;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 8f * Time.deltaTime);

        if(transform.position.y > screenBounds.y + objectHeight) {
            Destroy(gameObject);
        }
    }
}
