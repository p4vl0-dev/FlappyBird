using UnityEngine;

public class BaseMoving : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        _speed = 3f;
    }

    private void Update()
    {
        if(!GameState.Instance._isGameLost)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(1, 0) * -_speed * Time.deltaTime;

        if(transform.position.x <= -11.29f)
        {
            transform.position = new Vector3(11.37f, transform.position.y);
        }
    }
}
