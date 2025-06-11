using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x0200001D RID: 29
public class Shooting : MonoBehaviour
{
	// Token: 0x06000069 RID: 105 RVA: 0x000035C8 File Offset: 0x000017C8
	private void Update()
	{
		if (this.canShoot && Keyboard.current.qKey.wasPressedThisFrame && Time.time - this.lastShotTime >= 0.5f)
		{
			this.shooting.Play();
			Object.Instantiate<GameObject>(this.bulletPrefab, this.shootingPoint.position, Quaternion.identity);
			this.lastShotTime = Time.time;
		}
	}

	// Token: 0x0400006C RID: 108
	[SerializeField]
	private AudioSource shooting;

	// Token: 0x0400006D RID: 109
	public bool canShoot;

	// Token: 0x0400006E RID: 110
	public Transform shootingPoint;

	// Token: 0x0400006F RID: 111
	public GameObject bulletPrefab;

	// Token: 0x04000070 RID: 112
	private float lastShotTime;
}
