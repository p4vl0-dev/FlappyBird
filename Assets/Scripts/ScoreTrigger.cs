using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _pointSound; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _audioSource.clip = _pointSound;
            _audioSource.Play();
            ScoreManager.score += 1;
        }
    }
}
