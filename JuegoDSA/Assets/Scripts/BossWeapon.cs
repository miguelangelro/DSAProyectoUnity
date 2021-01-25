using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;
	public GameObject player;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	public bool cdv =false;

	void Start()
	{


		player = GameObject.Find("Player(Clone)");

	}
	public void Attack()
	{
		if (cdv == false)
		{
			player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
			cdv = true;
			Invoke("SetBoolBack", 0.7f);
		}
	}


	private void SetBoolBack()
	{
		cdv = false;
	}
	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerMovement>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
