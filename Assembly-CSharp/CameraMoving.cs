using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class CameraMoving : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Update()
	{
		this.horizontal = Input.GetAxis("Horizontal");
		base.transform.Translate(new Vector3(this.horizontal, 0f, 0f) * this.speed * Time.deltaTime);
	}

	// Token: 0x04000001 RID: 1
	[SerializeField]
	private float speed;

	// Token: 0x04000002 RID: 2
	private float horizontal;
}
