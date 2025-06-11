using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class EnemyBullet : MonoBehaviour
{
	// Token: 0x0600001C RID: 28 RVA: 0x000024E6 File Offset: 0x000006E6
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody2D>();
		this.rb.velocity = -base.transform.right * this.speed;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000251F File Offset: 0x0000071F
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ArrowStop"))
		{
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400001D RID: 29
	public float speed = 1f;

	// Token: 0x0400001E RID: 30
	private Rigidbody2D rb;
}
