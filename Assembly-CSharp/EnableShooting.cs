using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class EnableShooting : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x0000226C File Offset: 0x0000046C
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Shooting component = this.shootingObject.GetComponent<Shooting>();
			if (component != null)
			{
				component.canShoot = true;
			}
		}
	}

	// Token: 0x0400000D RID: 13
	public GameObject shootingObject;
}
