using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTankController : MonoBehaviour
{
    public GameObject pinkProjectile;

    float _interval = 2.5f;
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        while(_time >= _interval) {
            FirePinkBullet();
            _time -= _interval;
        }
    }

    void FirePinkBullet() {
        Instantiate(pinkProjectile, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
