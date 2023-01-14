using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public static float speed = 3f;
    public static int ScoreLimit = 10;

    private void Update(){

        if(ScoreManager.score == ScoreLimit){
            speed += 0.4f;
            ScoreLimit +=10;
            if(Spawner.timeToSpawn > Spawner.MinTimeToSpawn){
                Spawner.timeToSpawn -= 0.4f;
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
