using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public static float speed = 3f;
    private static float _currentScoreLimit = ScoreManager.ScoreLimit;

    private void Update()
    {
        if(ScoreManager.score == _currentScoreLimit)
        {
            speed += 0.4f;
            _currentScoreLimit +=10;
            if(Spawner.timeToSpawn > Spawner.MinTimeToSpawn && GameManager.instanceManager._isGameLosed == false)
            {
                Spawner.timeToSpawn -= 0.3f;
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
}
