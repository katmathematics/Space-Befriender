using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public float dropDistance = 1;

    private float hInput;

    private Vector3 startingPos;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public bool rightNext = true;

    public GameMaster gm;

    private AudioSource audioSource;
    public AudioClip death_sound;
    public AudioClip level_complete_sound;
    public AudioClip descent_sound;

    public int score = 0;

    private void Awake() {
    }

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        audioSource = GetComponent<AudioSource>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        hInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);
    }

    void LateUpdate() {
        Vector3 viewPos = transform.position;

        viewPos = CheckLayer(viewPos);

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * - 1 + (objectWidth + .5f), screenBounds.x - (objectWidth + .5f));
        
        if (viewPos.y < screenBounds.y * - 1 + (objectHeight + 2)) {
            transform.position = startingPos;
            audioSource.PlayOneShot(level_complete_sound, 1f);
            score = score + 1;
            gm.displayScore(score);
            rightNext = true;
        }
        else {
            transform.position = viewPos;
        }
    }

    private Vector3 CheckLayer(Vector3 viewPos){
        if (rightNext && screenBounds.x - (objectWidth + .5f) <= viewPos.x) {
            audioSource.PlayOneShot(descent_sound, 1f);
            viewPos.y = viewPos.y - dropDistance;
            rightNext = false;
        }
        else if (!rightNext && screenBounds.x * - 1 + (objectWidth + .5f) >= viewPos.x) {
            audioSource.PlayOneShot(descent_sound, 1f);
            viewPos.y = viewPos.y - dropDistance;
            rightNext = true;
        }

        return viewPos;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Projectile")) {
            audioSource.PlayOneShot(death_sound, 1f);
            gm.LevelLose(score);
            gameObject.SetActive(false); 
        }
    }
}
