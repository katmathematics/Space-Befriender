using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngledProjectile : MonoBehaviour
{
    //public float moveSpeed = 2f;

    private Vector2 screenBounds;
    private float objectHeight;
    public float speed = 8f;
    public float xSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(Vector2.right * xSpeed * Time.deltaTime);

        if(transform.position.y > screenBounds.y + objectHeight) {
            Destroy(gameObject);
        }
    }
}
