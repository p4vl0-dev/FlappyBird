using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public static float speed = 3f;
    public static int ScoreLimit = 10;

    private void Update(){

        if(ScoreManager.score == ScoreLimit){
            speed += 1f;
            ScoreLimit +=10;
            if(Spawner.timeToSpawn > Spawner.MinTimeToSpawn){
                Spawner.timeToSpawn -= 1f;
            }
        }
        if(gameObject.transform.position.x <= -11){
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public static void SetDefaults(){
        speed = 3f;
        ScoreLimit = 10;
    }
}
