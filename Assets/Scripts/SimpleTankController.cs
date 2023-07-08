using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTankController : MonoBehaviour
{
    public GameObject pinkProjectile;
    private AudioSource audioSource;
    public AudioClip fire_laser;

    public float moveSpeed = .5f;

    private float hDirection = -1;

    private Vector2 screenBounds;
    private float objectWidth;

    float _interval = 2.5f;
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
        audioSource = GetComponent<AudioSource>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        while(_time >= _interval) {
            FirePinkBullet();
            _time -= _interval;
        }

        transform.Translate(Vector2.right * hDirection * moveSpeed * Time.deltaTime);
        if (screenBounds.x - (objectWidth + .5f) <= transform.position.x) {
            hDirection = hDirection * -1;
        }
        else if (screenBounds.x * - 1 + (objectWidth + .5f) >= transform.position.x) {
            hDirection = hDirection * -1;
        }
    }

    void LateUpdate() {
        
    }

    void FirePinkBullet() {
        Instantiate(pinkProjectile, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
        audioSource.PlayOneShot(fire_laser, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
