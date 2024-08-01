using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float jumpForce;
    public static bool IsGameOver = false;
    [SerializeField] private Animator animator;
    [SerializeField] private VolumeProfile profile;
    public static float GameSpeed = 1;

    private void Start()
    {
        Application.targetFrameRate = 120;
        WallMove.SpeedMult = 1;
        StartCoroutine(ChangeColor());
        if (profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.hueShift.value = 0;
        }
        if (profile.TryGet(out ChromaticAberration chromatic))
        {
            chromatic.intensity.value = 0;
        }
        if (profile.TryGet(out FilmGrain filmGrain))
        {
            filmGrain.intensity.value = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI.Main.ShowMenu();
        }
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            if (profile.TryGet(out ColorAdjustments colorAdjustments))
            {
                colorAdjustments.hueShift.value += 1;
                if (colorAdjustments.hueShift.value == 180)
                {
                    colorAdjustments.hueShift.value = -180;
                }
            }
            if (profile.TryGet(out ChromaticAberration chromatic))
            {
                chromatic.intensity.value += 0.05f;
            }
            if (profile.TryGet(out FilmGrain filmGrain))
            {
                filmGrain.intensity.value += 0.05f;
            }

            WallMove.SpeedMult += 0.01f;
            GameSpeed += 0.002f;
            Time.timeScale = GameSpeed;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsGameOver = true;
        Scoreboard.Main.SaveScore();
        UI.Main.ShowMenu();
        UI.Main.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Scoreboard.Main.AddPoint();
    }
}
