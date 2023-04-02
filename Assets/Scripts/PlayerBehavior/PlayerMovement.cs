using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D _playerRb; //Компонент rigibody, объекта Player в инспекторе
    private bool _isGamePaused = false; //Проверка на паузу в игре

    [Header("AudioSources")]
    public AudioSource _audioSource;
    public AudioClip _wingSound, _hitSound;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GameManager.instanceManager._isGameLosed == false) //Не дает нажиматься кнопке ESC во время проигрыша
        {   
            _isGamePaused = !_isGamePaused; //Переключатель паузы

            if(_isGamePaused == true) //Запускает паузу
            {
                GameManager.instanceManager.Pause(); 
            }

            if(_isGamePaused == false) //Отключает меню паузы
            {
                GameManager.instanceManager.Continue();
            }
        }

        if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) && (GameManager.instanceManager._isGameLosed == false)) 
        //если игра не проиграна, то нажатия нужных клавиш проходит - иначе они отключаются
        {
            _audioSource.clip = _wingSound;
            _audioSource.Play();

            _playerRb.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            _playerRb.AddForce(Vector2.up * 260); //Прыжок
        }
    }

    private void OnCollisionEnter2D(Collision2D _collision2D) //При соприкосновении с коллайдером объектов
    {
        if(_collision2D.gameObject.tag == "pipePart")
        {
            _audioSource.clip = _hitSound;
            _audioSource.Play();

            GameManager.instanceManager.Lose();
        }
    }
}
