using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float lifetime = 5f;
    public float speed = 10f;
    public AudioSource hitSound;
    
    void Start() {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update() {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy") {
            Debug.Log("Enemy Hit");
            // Add score
            PlayerPrefs.SetInt("playerscore", 
                PlayerPrefs.GetInt("playerscore") + 1);
            hitSound.Play();
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Ground" 
            || col.gameObject.tag == "Wall") {
            hitSound.Play();
        }
    }
}