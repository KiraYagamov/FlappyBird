using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        float x = transform.position.x - speed * Time.deltaTime;
        float y = transform.position.y;
        transform.position = new Vector2(x, y);
    }
}
