using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip dieSound;

    private void OnCollisionEnter2D(Collision2D otherCollision) //При соприкосновении с коллайдером объектов
    {
        if(otherCollision.gameObject.GetComponent<PipePart>())
        {
            GameState.Instance.PlayerDies();

            audioSource.clip = dieSound;
            audioSource.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D otherCollision)
    {
        if(GameState.Instance._isGameLost)
        {   
            if(otherCollision.gameObject.GetComponent<BaseMoving>())
            {
                audioSource.clip = hitSound;
                audioSource.Play();

                StartCoroutine(WaitToLose(0.17f));
            }
        }
    }

    private IEnumerator WaitToLose(float _timeToLose)
    {
        yield return new WaitForSeconds(_timeToLose);

        GameState.Instance.Lose();
    }
}
