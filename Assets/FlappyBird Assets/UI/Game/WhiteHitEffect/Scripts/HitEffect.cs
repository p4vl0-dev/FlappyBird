using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private static Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void PlayHitEffect()
    {
        _animator.Play("HitEffect");
    }
}
