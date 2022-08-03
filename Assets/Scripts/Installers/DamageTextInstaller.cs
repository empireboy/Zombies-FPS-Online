using TMPro;
using UnityEngine;

public class DamageTextInstaller : MonoBehaviour
{
    [SerializeField]
    private DamageTextSO _damageTextSO;

    [SerializeField]
    private GameObject _rootObject;

    [SerializeField]
    private Transform _damageTextTransform;

    private float _currentDamage;
    private TextMeshProUGUI _currentText;
    private DamageText _currentDamageText;

    private void Awake()
    {
        _rootObject.GetComponent<IDamageable>().OnTakeDamage += OnTakeDamage;
    }

    private void OnTakeDamage(float damage)
    {
        damage = Mathf.Round(damage);

        if (!_currentText)
        {
            _currentDamageText = _damageTextSO.Create(_damageTextTransform.position, damage);
            _currentText = _currentDamageText.GetComponentInChildren<TextMeshProUGUI>();

            _currentDamage = damage;
        }
        else
            UpdateText(damage);
    }

    private void UpdateText(float damage)
    {
        _currentDamage += damage;

        _currentText.text = _currentDamage.ToString();
        _currentDamageText.ResetFade();
        _currentDamageText.transform.position = _damageTextTransform.position;
    }
}