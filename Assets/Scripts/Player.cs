using System.Data;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpDistance;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private BoxCollider2D boxcollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private bool onground()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizonInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizonInput * speed, rb.linearVelocity.y);

        /*if (horizonInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizonInput < 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }*/

        if (Input.GetKey(KeyCode.Space) && onground())
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpDistance);


    }
}
