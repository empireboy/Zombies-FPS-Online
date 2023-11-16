using UnityEngine;
using Zenject;

public class AnimationManager : IAnimatable
{
    private Animator _animator;

    [Inject]
    public void Construct(Animator animator)
    {
        _animator = animator;
    }

    public void PlayAnimation(string name)
    {
        _animator.SetTrigger(name);
    }
}