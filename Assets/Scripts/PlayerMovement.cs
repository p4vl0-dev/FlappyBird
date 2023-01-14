using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float jumpForce;
    public Rigidbody2D rb;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("pipePart")){
            GameManager.instanceManager.Lose();
        }
    }
}
