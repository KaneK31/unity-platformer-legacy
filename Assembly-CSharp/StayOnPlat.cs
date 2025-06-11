using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class StayOnPlat : MonoBehaviour
{
	// Token: 0x0600006B RID: 107 RVA: 0x0000363B File Offset: 0x0000183B
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.transform.SetParent(base.transform);
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x0000366A File Offset: 0x0000186A
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}
}
