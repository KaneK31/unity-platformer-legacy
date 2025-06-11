using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class Bullet : MonoBehaviour
{
	// Token: 0x06000008 RID: 8 RVA: 0x000021C0 File Offset: 0x000003C0
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody2D>();
		this.rb.velocity = base.transform.right * this.speed;
	}

	// Token: 0x04000009 RID: 9
	public float speed = 1f;

	// Token: 0x0400000A RID: 10
	private Rigidbody2D rb;
}
