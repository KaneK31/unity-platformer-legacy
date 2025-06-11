using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class BossCs : MonoBehaviour
{
	// Token: 0x06000012 RID: 18 RVA: 0x00002362 File Offset: 0x00000562
	private void Start()
	{
		this.currentHealth = this.maxHealth;
		this.hpbar.SetMaxHealth(this.maxHealth);
		this.anim = base.GetComponent<Animator>();
		this.gem3.SetActive(false);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000239C File Offset: 0x0000059C
	private void Update()
	{
		if (this.hasCollidedWithBullet)
		{
			this.Takedmg(1);
			this.hasCollidedWithBullet = false;
		}
		if (this.currentHealth == 14)
		{
			this.TeleportToTarget();
			return;
		}
		if (this.currentHealth == 9)
		{
			this.TeleportToTarget2();
			return;
		}
		if (this.currentHealth == 0)
		{
			Object.Destroy(base.gameObject);
			this.gem3.SetActive(true);
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002400 File Offset: 0x00000600
	public void Takedmg(int dmg)
	{
		this.currentHealth -= dmg;
		this.hpbar.SetHealth(this.currentHealth);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002421 File Offset: 0x00000621
	private void TeleportToTarget()
	{
		base.transform.position = this.targetPosition.position;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002439 File Offset: 0x00000639
	private void TeleportToTarget2()
	{
		base.transform.position = this.targetPosition2.position;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002451 File Offset: 0x00000651
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Bullet"))
		{
			this.hasCollidedWithBullet = true;
		}
	}

	// Token: 0x04000012 RID: 18
	public int maxHealth = 20;

	// Token: 0x04000013 RID: 19
	public int currentHealth;

	// Token: 0x04000014 RID: 20
	public BossHp hpbar;

	// Token: 0x04000015 RID: 21
	public Transform targetPosition;

	// Token: 0x04000016 RID: 22
	public Transform targetPosition2;

	// Token: 0x04000017 RID: 23
	private Animator anim;

	// Token: 0x04000018 RID: 24
	private bool hasCollidedWithBullet;

	// Token: 0x04000019 RID: 25
	public GameObject gem3;
}
