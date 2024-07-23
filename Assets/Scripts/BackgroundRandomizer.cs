using UnityEngine;

public class BackgroundRandomizer : MonoBehaviour
{
    [SerializeField] private Sprite dayBg, nightBg;
    [SerializeField] private SpriteRenderer background;

    private void Start()
    {
        int rand = Random.Range(1, 100);
        if (rand < 30) background.sprite = nightBg;
        else background.sprite = dayBg;
    }
}
