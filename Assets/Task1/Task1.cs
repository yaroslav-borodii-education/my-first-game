using UnityEngine;

public class Task1 : Task2
{
    private PlayerController player;
    private float jumpForce = 5f;
    private bool isGrounded;

    public Task1(PlayerController player)
    {
        this.player = player;
    }

    public void Update()
    {
        isGrounded = player.IsGrounded();

        if (isGrounded)
        {
            player.animator.SetInteger("playerState", 0);
        }
    }

    public void Jump()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            player.animator.SetInteger("playerState", 2);
        }
    }
}
