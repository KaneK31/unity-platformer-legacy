using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000015 RID: 21
public class CoinCollect : MonoBehaviour
{
	// Token: 0x06000044 RID: 68 RVA: 0x00002D27 File Offset: 0x00000F27
	private void Start()
	{
		this.UpdateCoinsUI();
		this.playerLife = Object.FindObjectOfType<PlayerLife>();
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002D3A File Offset: 0x00000F3A
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Coin") && this.canCollect)
		{
			base.StartCoroutine(this.CollectCoin(collision.gameObject));
		}
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002D69 File Offset: 0x00000F69
	private IEnumerator CollectCoin(GameObject coin)
	{
		this.canCollect = false;
		this.coinCollect.Play();
		Object.Destroy(coin);
		this.coins++;
		this.UpdateCoinsUI();
		if (this.coins == 20)
		{
			this.hp.Play();
			this.Health = GameObject.Find("Player").GetComponent<PlayerLife>();
			this.Health.GainLifeFromCoins();
			this.coins = 0;
			this.UpdateCoinsUI();
		}
		yield return new WaitForSeconds(this.cooldownTime);
		this.canCollect = true;
		yield break;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002D7F File Offset: 0x00000F7F
	private void UpdateCoinsUI()
	{
		this.Coins.text = "Coins: " + this.coins.ToString();
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002DA1 File Offset: 0x00000FA1
	public void ResetCoins()
	{
		this.coins = 0;
		this.UpdateCoinsUI();
	}

	// Token: 0x04000043 RID: 67
	public int coins;

	// Token: 0x04000044 RID: 68
	[SerializeField]
	private Text Coins;

	// Token: 0x04000045 RID: 69
	[SerializeField]
	private AudioSource coinCollect;

	// Token: 0x04000046 RID: 70
	[SerializeField]
	private AudioSource hp;

	// Token: 0x04000047 RID: 71
	private PlayerLife playerLife;

	// Token: 0x04000048 RID: 72
	private bool canCollect = true;

	// Token: 0x04000049 RID: 73
	[SerializeField]
	private float cooldownTime = 0.2f;

	// Token: 0x0400004A RID: 74
	private PlayerLife Health;
}
