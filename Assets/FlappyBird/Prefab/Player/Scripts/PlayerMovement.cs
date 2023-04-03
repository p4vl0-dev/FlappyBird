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
        if(Input.GetKeyDown(KeyCode.Escape) && GameManager.instanceManager._isGameLosed == false) //Не дает нажиматься кнопке ESC во время проигрыша
        {   
            _isGamePaused = !_isGamePaused; //Переключатель паузы

            GameManager.instanceManager.MenuChanger(_isGamePaused);
        }

        if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && (GameManager.instanceManager._isGameLosed == false)) 
        //если игра не проиграна, то нажатия нужных клавиш проходит - иначе они отключаются
        {
            audioSource.clip = wingSound;
            audioSource.Play();

            playerRb.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            playerRb.AddForce(Vector2.up * 260); //Прыжок
        }
    }

    private void OnCollisionEnter2D(Collision2D _collision2D) //При соприкосновении с коллайдером объектов
    {
        if(_collision2D.gameObject.tag == "pipePart")
        {
            audioSource.clip = hitSound;
            audioSource.Play();

            GameManager.instanceManager.Lose();
        }
    }
}
