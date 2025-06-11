using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class MoveBackground : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x000020EA File Offset: 0x000002EA
	private void Start()
	{
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020EC File Offset: 0x000002EC
	private void Update()
	{
		this.x = base.transform.position.x;
		this.x += this.speed * Time.deltaTime;
		base.transform.position = new Vector3(this.x, base.transform.position.y, base.transform.position.z);
		if (this.x <= this.PontoDeDestino)
		{
			Debug.Log("hhhh");
			this.x = this.PontoOriginal;
			base.transform.position = new Vector3(this.x, base.transform.position.y, base.transform.position.z);
		}
	}

	// Token: 0x04000005 RID: 5
	public float speed;

	// Token: 0x04000006 RID: 6
	private float x;

	// Token: 0x04000007 RID: 7
	public float PontoDeDestino;

	// Token: 0x04000008 RID: 8
	public float PontoOriginal;
}
