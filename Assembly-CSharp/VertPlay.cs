using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class VertPlay : MonoBehaviour
{
	// Token: 0x0600006E RID: 110 RVA: 0x0000369C File Offset: 0x0000189C
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

	// Token: 0x04000071 RID: 113
	[SerializeField]
	private GameObject[] waypoints;

	// Token: 0x04000072 RID: 114
	private int currentWaypoint;

	// Token: 0x04000073 RID: 115
	[SerializeField]
	private float speed = 5f;
}
