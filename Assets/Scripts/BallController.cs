using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    PlayerInput playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerInput = new PlayerInput();

        playerInput.BallCatchInputs.Touch.started += onTouch;
    }

    void Start()
    {
        rb.velocity = (Vector2.up + Vector2.right) * 10f;
    }

    void onTouch(InputAction.CallbackContext context)
    {
        rb.velocity = Vector2.zero;
        sr.color = Color.green;
        Debug.Log($"ball position: {gameObject.transform.position}");
        Debug.Log($"touch position: {Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>())}");
    }

    void OnEnable()
    {
        playerInput.BallCatchInputs.Enable();
    }

    void OnDisable()
    {
        playerInput.BallCatchInputs.Disable();
    }
}
