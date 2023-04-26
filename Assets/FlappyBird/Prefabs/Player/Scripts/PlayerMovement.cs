using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb; //Компонент rigibody, объекта Player в инспекторе
    private bool _isGamePaused = false; //Проверка на паузу в игре

    [Header("AudioSources")]
    public AudioSource audioSource;
    public AudioClip wingSound, hitSound;

    private void Update()
    {
        CheckingPause();
        Jump();
    }

    private void Jump()
    {
        if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && (GameState.Instance._isGameLost == false)) 
        //если игра не проиграна, то нажатия нужных клавиш проходит - иначе они отключаются
        {
            audioSource.clip = wingSound;
            audioSource.Play();

            playerRb.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            playerRb.AddForce(Vector2.up * 260); //Прыжок
        }
    }
    
    private void CheckingPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameState.Instance._isGameLost == false) //Не дает нажиматься кнопке ESC во время проигрыша
        {   
            _isGamePaused = !_isGamePaused; //Переключатель паузы

            GameState.Instance.PauseChange(_isGamePaused);
        }
    }

    private void OnCollisionEnter2D(Collision2D otherCollision) //При соприкосновении с коллайдером объектов
    {
        if(otherCollision.gameObject.GetComponent<PipePart>())
        {
            audioSource.clip = hitSound;
            audioSource.Play();

            GameState.Instance.Lose();
        }
    }
}
