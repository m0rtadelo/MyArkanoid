using UnityEngine;

public class Player : MonoBehaviour
{
    public int Width = 4;
    [SerializeField]
    private float speed = 30000;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        if (GameController.Status == 0) {
            Vector2 direction = Vector2.zero;
            float inputValue = Input.GetAxisRaw("Horizontal");
            if (inputValue == 1) {
                direction = Vector2.right;
            }
            if (inputValue == -1) {
                direction = Vector2.left;
            }
            rb.AddForce(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag.Equals("Present")) {
            Vector3 actual = transform.localScale;
            actual.x = actual.x + 0.5f;
            this.transform.localScale = actual;
            Destroy(other.gameObject);
        }
    }
}
