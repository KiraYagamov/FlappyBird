using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private float speed;
    public static float SpeedMult = 1;

    private void Update()
    {
        float x = transform.position.x - speed * SpeedMult * Time.deltaTime;
        float y = transform.position.y;
        transform.position = new Vector2(x, y);
    }
}
