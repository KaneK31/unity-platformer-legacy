using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class FanRotation : MonoBehaviour
{
	// Token: 0x06000003 RID: 3 RVA: 0x000020AA File Offset: 0x000002AA
	private void FixedUpdate()
	{
		base.transform.Rotate(this.angles * this.speed);
	}

	// Token: 0x04000003 RID: 3
	[SerializeField]
	private float speed;

	// Token: 0x04000004 RID: 4
	private Vector3 angles = new Vector3(0f, 0f, -1f);
}
