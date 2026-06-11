using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class NekoChanController : MonoBehaviour
{
	[SerializeField] Sprite[] idle;
	[SerializeField] Sprite jump;
	Rigidbody2D rigid2D;
	const float jumpPower = 700;
	float time = 0;
	int idx = 0;
	SpriteRenderer spriteRenderer;

	private void Start()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		// 左移動
		if (Keyboard.current.leftArrowKey.isPressed)
		{
			transform.Translate(-0.15f, 0, 0);
			Vector3 Scale = transform.localScale;
			Scale.x = -Mathf.Abs(Scale.x);
			transform.localScale = Scale;

			// 歩行アニメーション
			time += Time.deltaTime;
			if (time > 0.05f)
			{
				time = 0;
				spriteRenderer.sprite = idle[idx];
				idx = 1 - idx;
			}
		}

		// 右移動
		if (Keyboard.current.rightArrowKey.isPressed)
		{
			transform.Translate(0.15f, 0, 0);
			Vector3 Scale = transform.localScale;
			Scale.x = Mathf.Abs(Scale.x);
			transform.localScale = Scale;

			// 歩行アニメーション
			time += Time.deltaTime;
			if (time > 0.05f)
			{
				time = 0;
				spriteRenderer.sprite = idle[idx];
				idx = 1 - idx;
			}
		}

		// ジャンプ
		if (Keyboard.current.upArrowKey.wasPressedThisFrame && rigid2D.linearVelocityY == 0)
		{
			rigid2D.AddForce(transform.up * jumpPower);
		}

		// ジャンプが確認された場合、スプライトを変更
		if (rigid2D.linearVelocityY != 0)
		{
			spriteRenderer.sprite = jump;
		}
		// 地面についた場合、スプライトをフィールド「idle」に変更
		else
		{
			spriteRenderer.sprite = idle[idx];
		}
	}
}