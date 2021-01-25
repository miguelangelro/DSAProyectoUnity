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
			GameManager.instance.winnerText.text = "Score: " + GameManager.instance.score;
			GameManager.instance.winnerText.fontSize = 45;
			GameManager.instance.winner.SetActive(true);
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public void setCurrentHealth(int currentHealth)
	{
		this.currentHealth = currentHealth;
	}

}
