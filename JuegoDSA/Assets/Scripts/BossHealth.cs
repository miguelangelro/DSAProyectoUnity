using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 1500;
	public int currentHealth = 1500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		currentHealth -= damage;

		if (currentHealth <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (currentHealth <= 0)
		{
			Die();
			
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		GameManager.instance.winnerText.text = "Score: " + GameManager.instance.score;
		GameManager.instance.winnerText.fontSize = 45;
		GameManager.instance.winner.SetActive(true);

		if (Application.platform == RuntimePlatform.Android)
		{
			string score = GameManager.instance.score + "," + GameManager.instance.currentHealth;
			AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			currentActivity.Call("resultadoScore", score);//resultadoScore es el method en UnityPlayer
		}
	}

	public void setCurrentHealth(int currentHealth)
	{
		this.currentHealth = currentHealth;
	}

}
