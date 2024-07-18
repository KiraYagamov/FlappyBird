using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float jumpForce;
    public static bool IsGameOver = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.Main.ShowMenu();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsGameOver = true;
        Scoreboard.Main.SaveScore();
        UI.Main.ShowMenu();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Scoreboard.Main.AddPoint();
    }
}
