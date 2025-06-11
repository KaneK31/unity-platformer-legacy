using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class EnemyShooting : MonoBehaviour
{
	// Token: 0x0600002E RID: 46 RVA: 0x000028A9 File Offset: 0x00000AA9
	private void Update()
	{
		if (Time.time - this.lastShotTime >= this.shootingInterval)
		{
			this.Shoot();
			this.lastShotTime = Time.time;
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000028D0 File Offset: 0x00000AD0
	private void Shoot()
	{
		this.Fireshooting.Play();
		GameObject gameObject = Object.Instantiate<GameObject>(this.bulletPrefab, this.shootingPoint.position, Quaternion.identity);
		gameObject.GetComponent<Rigidbody2D>().velocity = -this.shootingPoint.right * gameObject.GetComponent<EnemyBullet>().speed;
	}

	// Token: 0x0400002B RID: 43
	[SerializeField]
	private AudioSource Fireshooting;

	// Token: 0x0400002C RID: 44
	public Transform shootingPoint;

	// Token: 0x0400002D RID: 45
	public GameObject bulletPrefab;

	// Token: 0x0400002E RID: 46
	public float shootingInterval = 1f;

	// Token: 0x0400002F RID: 47
	private float lastShotTime;
}
