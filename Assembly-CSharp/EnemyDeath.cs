using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class EnemyDeath : MonoBehaviour
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002551 File Offset: 0x00000751
	private void Start()
	{
		this.anim = base.gameObject.GetComponent<Animator>();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002564 File Offset: 0x00000764
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > base.transform.position.y)
		{
			this.Die();
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000025A0 File Offset: 0x000007A0
	private void OnTriggerEnter2D(Collider2D other)
	{
		AudioManager component = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		if (other.CompareTag("Bullet"))
		{
			this.Die();
			component.PlayEnemyDieSound();
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000025D6 File Offset: 0x000007D6
	public void Die()
	{
		this.anim.SetTrigger("death");
		base.StartCoroutine(this.DestroyAfterAnimation());
	}

	// Token: 0x06000023 RID: 35 RVA: 0x000025F5 File Offset: 0x000007F5
	private IEnumerator DestroyAfterAnimation()
	{
		yield return new WaitForSeconds(0.3f);
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x0400001F RID: 31
	[SerializeField]
	private AudioSource EnemyDie;

	// Token: 0x04000020 RID: 32
	private Animator anim;
}
