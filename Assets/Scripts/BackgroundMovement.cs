using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private Transform _parentTransform;
    private float _speed;
    private float _currentScoreLimit;
    

    private void Start()
    {
        _currentScoreLimit = ScoreManager.ScoreLimit;
        _parentTransform = GameObject.Find("Background").GetComponent<Transform>();
        _speed = 1.5f;
    }

    private void Update()
    {
        if(transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(1, 0) * -_speed * Time.deltaTime;
    }
}
