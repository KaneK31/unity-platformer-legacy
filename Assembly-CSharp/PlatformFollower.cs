using System;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class PlatformFollower : MonoBehaviour
{
	// Token: 0x06000070 RID: 112 RVA: 0x00003768 File Offset: 0x00001968
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
	}

	// Token: 0x04000074 RID: 116
	[SerializeField]
	private GameObject[] waypoints;

	// Token: 0x04000075 RID: 117
	private int currentWaypoint;

	// Token: 0x04000076 RID: 118
	[SerializeField]
	private float speed = 5f;
}
