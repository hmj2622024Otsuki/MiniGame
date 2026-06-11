using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SocialPlatforms.Impl;

public class CanNekoManager : MonoBehaviour
{
	public int score;

	private void Start()
	{
		score = 0;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("neko_chan"))
		{
			score++;
			Debug.Log(score);
			Destroy(gameObject);
			// ÉXÉRÉAÇ≤Ç∆è¡Ç≥ÇÍÇÈÇ©ÇÁÇ±Ç±ÇÕéüâÒÇ»ÇÒÇ∆Ç©Ç∑ÇÈ
		}
	}
}
