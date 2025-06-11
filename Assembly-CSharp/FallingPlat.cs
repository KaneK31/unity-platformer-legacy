using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class FallingPlat : MonoBehaviour
{
	// Token: 0x0600003A RID: 58 RVA: 0x00002C0F File Offset: 0x00000E0F
	private void Start()
	{
		this.originalPosition = base.transform.position;
		this.rb = base.GetComponent<Rigidbody2D>();
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002C33 File Offset: 0x00000E33
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			base.StartCoroutine(this.Fall());
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002C54 File Offset: 0x00000E54
	private IEnumerator Fall()
	{
		yield return new WaitForSeconds(this.FallDelay);
		this.rb.bodyType = RigidbodyType2D.Dynamic;
		yield return new WaitForSeconds(5f);
		this.rb.bodyType = RigidbodyType2D.Static;
		base.transform.position = this.originalPosition;
		yield break;
	}

	// Token: 0x0400003A RID: 58
	[SerializeField]
	private float FallDelay = 1f;

	// Token: 0x0400003B RID: 59
	private float destoryDelay = 2f;

	// Token: 0x0400003C RID: 60
	private Vector2 originalPosition;

	// Token: 0x0400003D RID: 61
	[SerializeField]
	private Rigidbody2D rb;
}
