using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minYPosition, maxYPosition;
    private float _timer;
    public static float MinTimeToSpawn = 0.1f, timeToSpawn = 2f;
    
    private void Update()
    {
        if(_timer <= 0 && GameManager.instanceManager._isGameLosed == false)
        {
            _timer = timeToSpawn;
            GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity, transform);
            float rand = Random.Range(minYPosition, maxYPosition);
            pipe.transform.position = new Vector2(pipe.transform.position.x, rand);
        } 
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    public static void SetDefaults()
    {
        timeToSpawn = 2f;
    }
}
