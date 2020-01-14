using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HidedArea : MonoBehaviour
{
	private SpriteRenderer SpriteRenderer;
	private float _alpha;
	public float FadeDuration = 1;

	private void Start()
	{
		_alpha = float.MinValue;
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag( "Player") && _alpha == float.MinValue)
			_alpha = 1;
	}

	private void Update()
	{
		if (_alpha > 0) {
			_alpha -= (1f / FadeDuration) * Time.deltaTime;
			SpriteRenderer.material.SetFloat("_Alpha", _alpha);
		}
	}
}
