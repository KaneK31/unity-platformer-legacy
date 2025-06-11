using System;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class BgScroll : MonoBehaviour
{
	// Token: 0x06000041 RID: 65 RVA: 0x00002CB5 File Offset: 0x00000EB5
	private void Start()
	{
		this.mat = base.GetComponent<Renderer>().material;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00002CC8 File Offset: 0x00000EC8
	private void Update()
	{
		this.offset += Time.deltaTime * this.scrollSpeed / 10f;
		this.mat.SetTextureOffset("_MainTex", new Vector2(this.offset, 0f));
	}

	// Token: 0x04000040 RID: 64
	[Range(-1f, 1f)]
	public float scrollSpeed = 0.5f;

	// Token: 0x04000041 RID: 65
	private float offset;

	// Token: 0x04000042 RID: 66
	private Material mat;
}
