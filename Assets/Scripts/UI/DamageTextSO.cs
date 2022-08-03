using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Damage Text", menuName = "FPS/Damage Text")]
public class DamageTextSO : ScriptableObject
{
    [SerializeField]
    private float fadeOutSpeed = 0.5f;

    [SerializeField]
    private GameObject _textPrefab;

    public DamageText Create(Vector3 position, float damage)
    {
        GameObject gameObject = Instantiate(_textPrefab, position, Quaternion.identity);

        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        DamageText damageText = gameObject.GetComponent<DamageText>();

        damageText.fadeOutSpeed = fadeOutSpeed;

        text.text = damage.ToString();

        return damageText;
    }
}