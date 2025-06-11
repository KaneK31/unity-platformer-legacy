using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class RollingDeathBall : MonoBehaviour
{
	// Token: 0x06000031 RID: 49 RVA: 0x00002948 File Offset: 0x00000B48
	private void Update()
	{
		if (Vector2.Distance(this.waypoints[this.currentWaypoint].transform.position, base.transform.position) < 0.1f)
		{
			this.currentWaypoint++;
			if (this.currentWaypoint >= this.waypoints.Length)
			{
				this.currentWaypoint = 0;
			}
		}
		base.transform.position = Vector2.MoveTowards(base.transform.position, this.waypoints[this.currentWaypoint].transform.position, Time.deltaTime * this.speed);
		this.RotateRollingDeathBall();
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002A08 File Offset: 0x00000C08
	private void RotateRollingDeathBall()
	{
		float num = this.rollSpeed * Time.deltaTime;
		base.transform.Rotate(Vector3.forward, num);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002A34 File Offset: 0x00000C34
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerLife component = collision.gameObject.GetComponent<PlayerLife>();
			if (component != null)
			{
				component.LoseLife();
			}
		}
	}

	// Token: 0x04000030 RID: 48
	[SerializeField]
	private GameObject[] waypoints;

	// Token: 0x04000031 RID: 49
	private int currentWaypoint;

	// Token: 0x04000032 RID: 50
	[SerializeField]
	private float speed = 5f;

	// Token: 0x04000033 RID: 51
	[SerializeField]
	private float rollSpeed = 90f;
}
