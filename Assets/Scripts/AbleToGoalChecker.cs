using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class AbleToGoalChecker : MonoBehaviour
{
	[SerializeField] CanNekoManager canNekoManager;
	[SerializeField] GameObject goal2;

	private void Start()
	{
		goal2.SetActive(false);
	}

	// ƒS[ƒ‹‚Å‚«‚é‚©”»’è
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("neko_chan"))
		{
			if(canNekoManager.score >= 3)
			{
				Debug.Log("ƒS[ƒ‹‚Å‚«‚é");
				goal2.SetActive(true);
			}
			else
			{
				Debug.Log("ƒS[ƒ‹‚Å‚«‚È‚¢");
			}
		}
	}
}
