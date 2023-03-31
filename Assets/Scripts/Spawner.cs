using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minYPosition, maxYPosition;
    private float timer;
    public static float MinTimeToSpawn = 0.1f, timeToSpawn = 2f;
    
    private void Update()
    {
        if(timer <= 0 && GameManager.instanceManager._isGameLosed == false)
        {
            timer = timeToSpawn;
            GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
            float rand = Random.Range(minYPosition, maxYPosition);
            pipe.transform.position = new Vector2(pipe.transform.position.x, rand);
        } 
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public static void SetDefaults()
    {
        timeToSpawn = 2f;
    }
}
