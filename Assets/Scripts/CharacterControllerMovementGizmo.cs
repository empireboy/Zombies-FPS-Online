using UnityEngine;
using Zenject;

public class CharacterControllerMovementGizmo : MonoBehaviour
{
    public Color Color { get; set; }

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

        Gizmos.color = Color;
        Gizmos.DrawRay(_characterControllerMovement.Transform.position, _characterControllerMovement.MovementVector);
    }
}