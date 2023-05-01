using UnityEngine;

public class PipeMove : MonoBehaviour
{
    private float speed = 3f;
    

    private void Update()
    {
        if(!GameState.Instance._isGameLost)
        {
            Move();
        }
    }

    private void Move()
    {
        if(gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(1,0) * -speed * Time.deltaTime;
    }
}
