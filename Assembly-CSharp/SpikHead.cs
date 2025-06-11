using System;
using UnityEngine;

// Token: 0x02000011 RID: 17
public class SpikHead : MonoBehaviour
{
	// Token: 0x06000035 RID: 53 RVA: 0x00002A8C File Offset: 0x00000C8C
	private void Update()
	{
		if (this.attacking)
		{
			base.transform.Translate(this.destination * Time.deltaTime * this.speed);
			return;
		}
		if (!this.attacking)
		{
			this.checkForPlayer();
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002ACC File Offset: 0x00000CCC
	private void checkForPlayer()
	{
		this.CalcDir();
		this.CalcDir();
		RaycastHit2D raycastHit2D = Physics2D.Raycast(base.transform.position, this.directions, this.range, this.playerLayer);
		Debug.DrawRay(base.transform.position, this.directions, Color.blue);
		if (raycastHit2D.collider != null)
		{
			Vector3 normalized = (raycastHit2D.collider.transform.position - base.transform.position).normalized;
			this.attacking = true;
			this.destination = normalized * this.speed;
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002B84 File Offset: 0x00000D84
	private void CalcDir()
	{
		this.directions = -base.transform.up * this.range;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002BA8 File Offset: 0x00000DA8
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<PlayerLife>().LoseLife();
		}
		if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Trap"))
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x04000034 RID: 52
	[SerializeField]
	private float speed;

	// Token: 0x04000035 RID: 53
	[SerializeField]
	private float range;

	// Token: 0x04000036 RID: 54
	[SerializeField]
	private LayerMask playerLayer;

	// Token: 0x04000037 RID: 55
	private Vector3 destination;

	// Token: 0x04000038 RID: 56
	private bool attacking;

	// Token: 0x04000039 RID: 57
	private Vector3 directions;
}
