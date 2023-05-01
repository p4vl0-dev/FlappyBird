using UnityEngine;

public class PipePart : MonoBehaviour
{
    [Header("Collider")]
    public BoxCollider2D boxCollider2D;

    private void Update()
    {
        if(GameState.Instance._isGameLost)
        {
            boxCollider2D.enabled = false;
        }
    }
}
