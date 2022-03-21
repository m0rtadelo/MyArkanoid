using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public int Strength = 1;
  [SerializeField]
  private float speed = 300;
  private Rigidbody2D rb;
  private GameController gc;
  private float MaxVelocity = 10;
  void Start()
  {
    StartCoroutine(Wait3());
        GameObject go;
        go = GameObject.Find("Game");
        gc = go.GetComponent<GameController>();    
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag.Equals("Player")) {
        Player player = other.gameObject.GetComponent<Player>();
        Instantiate(gc.SoundTouch2Prefab, this.transform.position, Quaternion.identity);
        float capsuleWidth = player.Width;//other.gameObject.transform.localScale.x;
        float capsuleX = other.gameObject.transform.position.x;
        float ballX = transform.position.x;
        float range = capsuleWidth / 2;
        float offset = Mathf.Abs(ballX - capsuleX);
        float finalVelocity;
        Debug.Log("Capsule w: " + capsuleWidth + " touched c:" + capsuleX + " b:" + ballX + " o:" + (offset));
        if (ballX < capsuleX) {
            rb.AddForce(Vector2.left * speed * (offset / range));
        } else if (ballX > capsuleX){
            rb.AddForce(Vector2.right * speed * (offset / range));
        }
        finalVelocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);
        // Debug.Log("Velocity after boost: " + finalVelocity + " " + MaxVelocity / finalVelocity);
        Vector2 normal = new Vector2();
        normal.x = rb.velocity.x * (MaxVelocity / finalVelocity);
        normal.y = rb.velocity.y * (MaxVelocity / finalVelocity);
        rb.velocity = normal;
        // Debug.Log("Velocity after normals: " + Mathf.Abs(normal.x) + Mathf.Abs(normal.y));

    } else if (other.gameObject.tag.Equals("Brick")) {
        Instantiate(gc.SoundTouch1Prefab, this.transform.position, Quaternion.identity);
    } else {
        Instantiate(gc.SoundTouch2Prefab, this.transform.position, Quaternion.identity);
    }
  }

  private void InitBall()
  {
    Vector2 force;
    int randomInt = (int)Random.Range(0, 9);
    force.x = randomInt < 5 ? -1 : 1;
    force.y = 1;
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(force * speed);
    //initialVelocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);
    //Debug.Log("InitialVelocity: " + initialVelocity);
  }
  IEnumerator Wait3()
  {
    yield return new WaitForSeconds(3);
    InitBall();
  }
}
