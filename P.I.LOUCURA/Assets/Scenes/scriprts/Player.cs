 using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int life = 3;
    public int lifeMax;
    public GameObject bullet;
    public Transform foot;
    bool groundCheck;
    public int speed = 5, jumpStrength = 5, bulletSpeed = 8;
    float horizontal;
    public Rigidbody2D body;
    public Animator animator;

    public int direction = 1;
    public int score;
    public TMP_Text texto;
    public string TMP_Text;
    [SerializeField] private Bullet bulletprefab;
    public GameManangerScript gameMananger;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        lifeMax = life;
    }
   void Update()
    {
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));
        }
        if (horizontal != 0)//Para GetAxisRaw
        {
            direction = (int)horizontal;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
        UpdateScoreText();

        texto.text = "Paginas do livro :10/" + score.ToString();

        horizontal = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        if (Mathf.Abs(horizontal) > 0)
        {
            animator.SetBool("Speed", true);
        }
        else
        {
            animator.SetBool("Speed", false);
        }

        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);


        /*Para quem está usando GetAxis
        if(horizontal < 0)
        {
            direction = -1;
        } else if(horizontal > 0)
        {
            direction = 1;
        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
           
            if (life <= 0 && !isDead)
            {
                isDead = true;
                gameMananger.GameOver();
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Aumenta"))
        {
            score += 1;
            Destroy(collision.gameObject);
            UpdateScoreText();
        }
        if (collision.gameObject.CompareTag("Divide"))
        {
            score /= 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("MorreVoid"))
        {
            isDead = true;
            gameMananger.GameOver();
            Destroy(gameObject);
        }
    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
    }
    */
    private void UpdateScoreText()
    {
    }
   

}