using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Checkpoint : MonoBehaviour
{
	// Token: 0x0600000A RID: 10 RVA: 0x00002208 File Offset: 0x00000408
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && !this.HalfCheck)
		{
			this.HalfCheck = true;
			this.CheckPoint.Play();
			PlayerLife component = other.GetComponent<PlayerLife>();
			if (component != null)
			{
				component.UpdateSpawnPoint(base.transform.position);
			}
		}
	}

	// Token: 0x0400000B RID: 11
	private bool HalfCheck;

	// Token: 0x0400000C RID: 12
	[SerializeField]
	private AudioSource CheckPoint;
}
