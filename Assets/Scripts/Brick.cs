using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private int Strength = 1;
    [SerializeField]
    private GameObject presentPrefab;
    private GameController lc;
    private SpriteRenderer sr;
    void Start()
    {
        GameObject go;
        go = GameObject.Find("Game");
        lc = go.GetComponent<GameController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Color[] colors = new Color[] { Color.white, Color.green, Color.yellow, Color.red };
        sr.color = colors[Strength];
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if(other.gameObject.tag.Equals("Ball"))
        {
            Touched(ball.Strength);
        }
    }

    private void Touched(int Strength) {
        GameController.Points += Strength;
        this.Strength -= Strength;
        if (this.Strength < 1) {
            destroy();
        }
    }

    private void destroy() {
        Instantiate(lc.particlePrefab, transform.position, Quaternion.identity);
        // Instantiate(presentPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        lc.checkLevel();
    }

    private void OnDestroy() {
    }
}
