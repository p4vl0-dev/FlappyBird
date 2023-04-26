using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private Transform _transform;
    public GameObject backgroundPrefab;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(_transform.childCount < 2)
        {
            CreateBackground(backgroundPrefab);
        }
    }

    private void CreateBackground(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(15, -0.78f,0), Quaternion.identity, _transform);
    }
}
