using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float movingSpeed = 3f;

    [SerializeField] private float raycastDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Task6 saveData;

    private bool facingRight = false;

    private float moveInput;
    private float levelWidth;

    private int score = 0;
    private int bestScore;

    public Animator animator;

    private Task2 currentState;

    private void Start()
    {
        currentState = new Task1(this);
        animator = GetComponent<Animator>();
        levelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)).x + 0.5f;
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    private void Update()
    {
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1);
            }
            else
            {
                animator.SetInteger("playerState", 0);
            }

            if(transform.position.x > levelWidth) transform.position = new Vector3(-levelWidth, transform.position.y, transform.position.z);
			else if(transform.position.x < -levelWidth) transform.position = new Vector3(levelWidth, transform.position.y, transform.position.z);

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (Input.GetButtonDown("Jump"))
            {
                currentState.Jump();
            }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Egg"))
        {
            CollectEgg(other.gameObject);
        }
    }

    private void CollectEgg(GameObject egg)
    {
        Destroy(egg);
        score++;
        Debug.Log("Score: " + score);
        if(score > PlayerPrefs.GetInt("bestScore")) 
        {
            bestScore = score;
            saveData.SaveBestScore(bestScore);
        }
        text.text = $"Score: {score}\nBest Score: {bestScore}";
        
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);

        return hit.collider != null;
    }
}