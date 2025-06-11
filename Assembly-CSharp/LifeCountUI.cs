using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000017 RID: 23
public class LifeCountUI : MonoBehaviour
{
	// Token: 0x0600004C RID: 76 RVA: 0x00002DDC File Offset: 0x00000FDC
	private void Update()
	{
		if (this.playerLife != null && this.lifeCountText != null)
		{
			this.lifeCountText.text = "Lives: " + this.playerLife.lives.ToString();
		}
	}

	// Token: 0x0400004C RID: 76
	public Text lifeCountText;

	// Token: 0x0400004D RID: 77
	public PlayerLife playerLife;
}
