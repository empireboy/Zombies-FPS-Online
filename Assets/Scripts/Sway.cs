using System;
using UnityEngine;
using Zenject;

public class Sway : ITickable
{
	private readonly Settings _settings;
	private readonly PlayerInputState _playerInputState;
	private readonly Transform _transform;
	private readonly Vector3 _startPosition;

	public Sway(Settings settings, PlayerInputState playerInputState, Transform transform)
    {
		_settings = settings;
		_playerInputState = playerInputState;
		_transform = transform;

		_startPosition = _transform.localPosition;
	}

	public void Tick()
    {
		Vector3 swayPosition = Vector3.zero;

		swayPosition.x = -_playerInputState.rotation.x * _settings.swayAmount.x;
		swayPosition.y = -_playerInputState.rotation.y * _settings.swayAmount.y;

		swayPosition.x = Mathf.Clamp(swayPosition.x, -_settings.maxSwayAmount.x, _settings.maxSwayAmount.x);
		swayPosition.y = Mathf.Clamp(swayPosition.y, -_settings.maxSwayAmount.y, _settings.maxSwayAmount.y);

		_transform.localPosition = Vector3.Lerp(_transform.localPosition, _startPosition + swayPosition, Time.deltaTime * _settings.swaySpeed);
	}

	[Serializable]
	public class Settings
	{
		public float swaySpeed;
		public Vector2 swayAmount;
		public Vector2 maxSwayAmount;
	}
}