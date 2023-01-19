using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D Player; //Компонент rigibody, объекта Player в инспекторе
    private bool isGamePaused = false; //Проверка на паузу в игре

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&GameManager.instanceManager.isGameLosed == false) //Не дает нажиматься кнопке ESC во время проигрыша
        {   
            isGamePaused = !isGamePaused; //Переключатель паузы
            if(isGamePaused == true) //Запускает паузу
            {
                GameManager.instanceManager.Pause(); 
            }
            if(isGamePaused == false) //Отключает меню паузы
            {
                GameManager.instanceManager.Continue();
            }
        }

        if(((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))&&(GameManager.instanceManager.isGameLosed == false)) //если игра не проиграна, то нажатия нужных клавиш проходит - иначе они отключаются
        {
            Player.velocity = new Vector2(0f, 0f); //Скорость по осям, чтобы отталкиваться в любой точке при любой скорости падения - я убираю скорость по y на 0. (Velocity - сопротивление воздуха)
            Player.AddForce(Vector2.up * 235); //Прыжок
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //При соприкосновении с коллайдером объектов
    {
        if(other.gameObject.CompareTag("pipePart"))
        {
            GameManager.instanceManager.Lose(); //Инициализирует проигрыш
        }
    }
}
