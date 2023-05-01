using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minYPosition, maxYPosition;
    private float _timer;
    public float timeToSpawnPipe = 2f;
    
    private void Update()
    {
        if(!GameState.Instance._isGameLost)
        {
            if(_timer <= 0)
            {
                _timer = timeToSpawnPipe;

                SpawnPipe();
            } 
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity, transform);

        float rand = Random.Range(minYPosition, maxYPosition);

        pipe.transform.position = new Vector2(pipe.transform.position.x, rand);
    }
}
