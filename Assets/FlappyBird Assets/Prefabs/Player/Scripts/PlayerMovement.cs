using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField] private Rigidbody2D playerRb; //Компонент rigibody, объекта Player в инспекторе

    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip wingSound;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!GameState.Instance._isGameLost)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))) 
        {
            audioSource.clip = wingSound;
            audioSource.Play();

            animator.Play("Flaping"); 

            playerRb.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            playerRb.AddForce(Vector2.up * 260); //Прыжок
        }
    }
}
