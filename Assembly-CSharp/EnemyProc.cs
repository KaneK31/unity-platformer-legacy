using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class EnemyProc : MonoBehaviour
{
	// Token: 0x06000029 RID: 41 RVA: 0x0000278F File Offset: 0x0000098F
	public void ActivateProjectiles()
	{
		this.lifetime = 0f;
		base.gameObject.SetActive(true);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000027A8 File Offset: 0x000009A8
	private void Update()
	{
		float num = this.speed * Time.deltaTime;
		base.transform.Translate(num, 0f, 0f);
		this.lifetime += Time.deltaTime;
		if (this.lifetime > this.resetTime)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002804 File Offset: 0x00000A04
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Trap"))
		{
			base.gameObject.SetActive(false);
		}
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<PlayerLife>().LoseLife();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002881 File Offset: 0x00000A81
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ArrowStop"))
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x04000028 RID: 40
	[SerializeField]
	private float speed;

	// Token: 0x04000029 RID: 41
	[SerializeField]
	private float resetTime;

	// Token: 0x0400002A RID: 42
	private float lifetime;
}
