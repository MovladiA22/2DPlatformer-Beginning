using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Warrior _warrior;

    private readonly int IsRan = Animator.StringToHash(nameof(IsRan));
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    private void OnEnable()
    {
        _playerMovement.Run += ToggleRunning;
        _warrior.Attacked += ActivateAttack;
    }

    private void OnDisable()
    {
        _playerMovement.Run -= ToggleRunning;
        _warrior.Attacked -= ActivateAttack;
    }

    private void ToggleRunning(bool isRan) =>
        _animator.SetBool(IsRan, isRan);

    private void ActivateAttack() =>
        _animator.SetTrigger(Attack);
}
