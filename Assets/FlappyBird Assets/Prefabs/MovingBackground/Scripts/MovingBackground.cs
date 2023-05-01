using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    private float speed;
    private float direction;

    private void Start()
    {
        speed = 1f;
        direction = -1;
    }

    void Update()
    {
        if(!GameState.Instance._isGameLost)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(1, 0) * speed * direction * Time.deltaTime;

        if(transform.position.x <= -11.14f)
        {
            transform.position = new Vector3(11.14f, 0.5f);
        }
    }
}
