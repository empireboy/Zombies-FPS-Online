using TMPro;
using UnityEngine;

public class DamageFlickerInstaller : MonoBehaviour
{
    [SerializeField]
    private float _flickerSpeed = 1;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private AnimationCurve _animationCurve;

    [SerializeField]
    private Renderer _renderer;

    [SerializeField]
    private GameObject _rootObject;

    private float _time = 1;

    private void Awake()
    {
        _rootObject.GetComponent<IDamageable>().OnTakeDamage += OnTakeDamage;
    }

    private void OnTakeDamage(float damage)
    {
        _time = 0;
    }

    private void Update()
    {
        if (_time * _flickerSpeed >= 1)
            return;

        _renderer.material.color = Color.Lerp(
            Color.white,
            _color,
            _animationCurve.Evaluate(_time * _flickerSpeed)
        );

        _time += Time.deltaTime;

        if (_time * _flickerSpeed >= 1)
            _renderer.material.color = Color.white;
    }
}