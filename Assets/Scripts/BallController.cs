using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = (Vector2.up + Vector2.right) * 10f;
    }

    void OnTouch(InputValue value)
    {
        rb.velocity = Vector2.zero;
        sr.color = Color.green;
        Debug.Log($"ball position: {gameObject.transform.position}");
        Debug.Log($"touch position: {Camera.main.ScreenToWorldPoint(value.Get<Vector2>())}");
    }
}
