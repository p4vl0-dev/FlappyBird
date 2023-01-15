using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D Player;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Player.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            Player.AddForce(Vector2.up * 235);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("pipePart")){
            GameManager.instanceManager.Lose();
        }
    }
}
