using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pointSound; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            audioSource.clip = pointSound;
            audioSource.Play();
            ScoreManager.score += 1;
        }
    }
}
