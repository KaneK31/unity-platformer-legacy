using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class EnemyMovement : MonoBehaviour
{
	// Token: 0x06000025 RID: 37 RVA: 0x0000260C File Offset: 0x0000080C
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
		this.character = base.GetComponent<SpriteRenderer>();
		this.enemyDeathScript = base.GetComponent<EnemyDeath>();
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002634 File Offset: 0x00000834
	private void Update()
	{
		if (this.waypoints.Length == 0)
		{
			return;
		}
		Transform transform = this.waypoints[this.currentWaypoint];
		base.transform.position = Vector2.MoveTowards(base.transform.position, transform.position, Time.deltaTime * this.speed);
		if (Vector2.Distance(transform.position, base.transform.position) < 0.1f)
		{
			if (this.currentWaypoint == 0 || this.currentWaypoint == 1)
			{
				this.character.flipX = !this.character.flipX;
			}
			this.currentWaypoint = (this.currentWaypoint + 1) % this.waypoints.Length;
		}
		this.animator.SetBool("running", true);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002710 File Offset: 0x00000910
	private void OnTriggerEnter2D(Collider2D collision)
	{
		AudioManager component = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > base.transform.position.y)
		{
			Debug.Log("Enemy destroyed");
			this.enemyDeathScript.Die();
			component.PlayEnemyDieSound();
		}
	}

	// Token: 0x04000021 RID: 33
	[SerializeField]
	private Transform[] waypoints;

	// Token: 0x04000022 RID: 34
	private int currentWaypoint;

	// Token: 0x04000023 RID: 35
	[SerializeField]
	private float speed = 5f;

	// Token: 0x04000024 RID: 36
	private Animator animator;

	// Token: 0x04000025 RID: 37
	private SpriteRenderer character;

	// Token: 0x04000026 RID: 38
	[SerializeField]
	private AudioSource EnemyDie;

	// Token: 0x04000027 RID: 39
	private EnemyDeath enemyDeathScript;
}
