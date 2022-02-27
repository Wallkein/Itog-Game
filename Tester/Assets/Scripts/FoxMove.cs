using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoxMove : Entity
{
    public float speed;
    public float jumpforce;
    public int Lives;
    private bool ground = false;
    public Text Lives_text;
    private int Points = 0;
    public Text Points_text;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public static FoxMove Instance { get; set; }
    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        Lives_text.text = Lives.ToString();
        Points_text.text = Points.ToString();

        if (Points >= 12)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
        }

        if (Lives <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

        if (ground) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (ground && Input.GetButton("Jump"))
            Jump();
    }
    private void Run()
    {
        if (ground) State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        ground = collider.Length > 1;

        if (!ground) State = States.jump;
    }

    public override void GetDamage()
    {
        Lives -= 1;
        Lives_text.text = Lives.ToString();
        Debug.Log(Lives);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gem")
        {
            Points += 1;
            Points_text.text = Points.ToString();
        }
        else if (collision.tag == "Cherry")
        {
            Points += 2;
            Points_text.text = Points.ToString();
        }
    }

}

public enum States
{
    idle,
    run,
    jump
}
