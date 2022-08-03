using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed = -1;
    public float fadeOutSpeed = 1;

    [SerializeField]
    private TextMeshProUGUI _text;

    private float _time = 0;

    public void ResetFade()
    {
        _time = 0;

        Color32 color = _text.color;

        color.a = 255;

        _text.color = color;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - moveSpeed * Time.deltaTime,
            transform.position.z
        );

        Color32 color = _text.color;

        color.a = (byte)Mathf.Lerp(255, 0, _time * fadeOutSpeed);

        _text.color = color;

        _time += Time.deltaTime;

        if (_time * fadeOutSpeed >= 1)
            Destroy(gameObject);
    }
}