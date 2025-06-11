using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class BossHp : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x00002477 File Offset: 0x00000677
	public void SetMaxHealth(int health)
	{
		this.slider.maxValue = (float)health;
		this.slider.value = (float)health;
		this.fill.color = this.gradient.Evaluate(1f);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000024AE File Offset: 0x000006AE
	public void SetHealth(int health)
	{
		this.slider.value = (float)health;
		this.fill.color = this.gradient.Evaluate(this.slider.normalizedValue);
	}

	// Token: 0x0400001A RID: 26
	public Slider slider;

	// Token: 0x0400001B RID: 27
	public Gradient gradient;

	// Token: 0x0400001C RID: 28
	public Image fill;
}
