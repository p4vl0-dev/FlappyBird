using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pointSound; 
    
    private void OnTriggerEnter2D(Collider2D _otherObject)
    {
        if(_otherObject.gameObject.GetComponent<PlayerMovement>())
        {
            audioSource.clip = pointSound;
            audioSource.Play();

            LocalScoreCounter.Instance.AddScore(1);
        }
    }
}
