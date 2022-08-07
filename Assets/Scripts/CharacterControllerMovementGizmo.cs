using UnityEngine;
using Zenject;

public class CharacterControllerMovementGizmo : MonoBehaviour
{
    [SerializeField]
    private Color _color;

    private CharacterControllerMovement _characterControllerMovement;

    [Inject]
    public void Construct(CharacterControllerMovement characterControllerMovement)
    {
        _characterControllerMovement = characterControllerMovement;
    }

    private void OnDrawGizmosSelected()
    {
        if (_characterControllerMovement == null)
            return;

        Gizmos.color = _color;
        Gizmos.DrawRay(_characterControllerMovement.Transform.position, _characterControllerMovement.MovementVector);
    }
}