using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = rb.linearVelocity.x;

        if (Mathf.Abs(moveX) < 0.01f)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (moveX < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (moveX > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
    }
}