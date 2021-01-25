﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bulletPrefab;
	public AudioClip disparo;

	public float bulletForce = 20f;

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.level > 2) {
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}
	}

	void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
		SoundManager.instance.PlaySingle(disparo);
	}
}
