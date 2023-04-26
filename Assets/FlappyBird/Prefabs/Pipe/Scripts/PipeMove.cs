using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public static float speed = 3f;
    private static float _currentScoreLimit;

    private void Start()
    {
        _currentScoreLimit = LocalScoreCounter.localScoreLimit;
    }

    private void Update()
    {
        if(LocalScoreCounter.localScore == _currentScoreLimit)
        {
            ChangeGameSpeed();

            if(PipeSpawner.timeToSpawnPipe > PipeSpawner.MinTimeToSpawnPipe && !GameState.Instance._isGameLost)
            {
                ChangePipeSpawnTime(0.3f);
            }
        }

        if(gameObject.transform.position.x <= -11)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(-1,0) * speed * Time.deltaTime;
    }

    public static void SetDefaults()
    {
        speed = 3f;
        _currentScoreLimit = 10;
    }

    private void ChangeGameSpeed()
    {
        speed += 0.4f;
        _currentScoreLimit +=10;
    }

    private void ChangePipeSpawnTime(float _time)
    {
        PipeSpawner.timeToSpawnPipe -= _time;
    }
}
