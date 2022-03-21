using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int Points = 0;
    public static int Status = 0;

    public AudioSource LevelSound;
    public GameObject SoundTouch1Prefab;
    public GameObject SoundTouch2Prefab;
    public GameObject particlePrefab;
    private AudioSource levelSuccess;

    void Start() {
        levelSuccess = GetComponent<AudioSource>();
    }

    void Update() {
        if (GameController.Status != 0) {
            LevelSound.Stop();
        }    
    }
    public void checkLevel() {
        GameObject[] result = GameObject.FindGameObjectsWithTag("Brick");
        if (result.Length == 0 && GameController.Status == 0) {
            GameController.Status = 1;
            Debug.Log("Level Completed!");
            levelSuccess.Play();
        }
    }

    public void RestartLevel() {
        Debug.Log("Restart level");
        GameController.Status = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
