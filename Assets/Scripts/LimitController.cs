using UnityEngine;

public class LimitController : MonoBehaviour
{
    public GameObject restart;
    private AudioSource aus;
    void Start() {
        aus = GetComponent<AudioSource>();        
    }

    void Update() {
        if (GameController.Status == 2) {
            restart.SetActive(true);
        } else {
            restart.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Ball")) {
            Debug.Log("Player die!");
            aus.Play();
            GameController.Status = 2;
        }
        Destroy(other.gameObject);
    }
}
