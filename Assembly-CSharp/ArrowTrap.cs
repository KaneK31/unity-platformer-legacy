using System;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class ArrowTrap : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x000022AC File Offset: 0x000004AC
	private void Attack()
	{
		this.CooldownTimer = 0f;
		this.arrows[this.FindArrow()].transform.position = this.firePoint.position;
		this.arrows[this.FindArrow()].GetComponent<EnemyProc>().ActivateProjectiles();
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002300 File Offset: 0x00000500
	private int FindArrow()
	{
		for (int i = 0; i < this.arrows.Length; i++)
		{
			if (!this.arrows[i].activeInHierarchy)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002332 File Offset: 0x00000532
	private void Update()
	{
		this.CooldownTimer += Time.deltaTime;
		if (this.CooldownTimer >= this.attackCD)
		{
			this.Attack();
		}
	}

	// Token: 0x0400000E RID: 14
	[SerializeField]
	private float attackCD;

	// Token: 0x0400000F RID: 15
	[SerializeField]
	private Transform firePoint;

	// Token: 0x04000010 RID: 16
	[SerializeField]
	private GameObject[] arrows;

	// Token: 0x04000011 RID: 17
	private float CooldownTimer;
}
