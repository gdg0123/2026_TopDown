using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Sprite[] spriteLeft;
    public Sprite[] spriteRight;
    public float frameTime = 0.15f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 input;
    private Vector2 velocity;
    private Sprite[] currentSprites;
    private int frameIndex = 0;
    private float timer = 0f;

    public float dashSpeed = 10f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector2 dashDirection;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        currentSprites = spriteRight;
        sr.sprite = currentSprites[0];
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateSpriteByMouse();


        if(input.sqrMagnitude <= 0.01f)
        {
            frameIndex = 0;
            sr.sprite = currentSprites[frameIndex];
            return;
        }

        timer += Time.deltaTime;

        if(timer >= frameTime)
        {
            timer = 0f;
            frameIndex++;

            if(frameIndex >= currentSprites.Length)
                frameIndex = 0;

            sr.sprite = currentSprites[frameIndex];
            
        }


        cooldownTimer -= Time.deltaTime;

        if(isDashing)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
                StopDash();
            return;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0f)
        {
            StartDash();
            return;
        }
    }

    private void UpdateSpriteByMouse()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (mouseWorld.x >= transform.position.x)
            ChangeSprites(spriteRight);
        else
            ChangeSprites(spriteLeft);
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.MovePosition(rb.position + dashDirection * dashSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    private void StartDash()
    {
        if (input.sqrMagnitude > 0.01f)
            dashDirection = input.normalized;
        else
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            dashDirection = ((Vector2)(mouseWorld - transform.position)).normalized;
        }

        isDashing = true;
        dashTimer = dashDuration;
        cooldownTimer = dashCooldown;
    }

    private void StopDash()
    {
        isDashing = false;
    }




    private void ChangeSprites(Sprite[] newSprites)
    {
        if(currentSprites == newSprites)
           return;

        
        currentSprites = newSprites;
        frameIndex = 0;
        timer = 0f;
        sr.sprite = currentSprites[frameIndex];
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        velocity = input.normalized * moveSpeed;

    }

    public void IncreaseMoveSpeed(float amount)
    {
        moveSpeed += amount;
    }

}
