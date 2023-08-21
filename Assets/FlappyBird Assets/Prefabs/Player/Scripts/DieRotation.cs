using UnityEngine;

public class DieRotation : MonoBehaviour
{
    private static Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void PlayDieRotate()
    {
        _animator.Play("DieRotate");
    }
}
