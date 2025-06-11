using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001B RID: 27
public class PlayerLife : MonoBehaviour
{
	// Token: 0x06000059 RID: 89 RVA: 0x00002F30 File Offset: 0x00001130
	private void Start()
	{
		if (PlayerPrefs.HasKey("PlayerLives"))
		{
			this.lives = PlayerPrefs.GetInt("PlayerLives");
		}
		this.movement = base.GetComponent<Rigidbody2D>();
		this.anim = base.GetComponent<Animator>();
		this.initialSpawnPoint = this.playerSpawnPoint.position;
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00002F87 File Offset: 0x00001187
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("BulletBoss"))
		{
			this.LoseLife();
		}
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00002FB4 File Offset: 0x000011B4
	public void LoseLife()
	{
		this.lives--;
		if (this.lives <= 0)
		{
			this.lives = 3;
			PlayerPrefs.SetInt("PlayerLives", this.lives);
			PlayerPrefs.Save();
			SceneManager.LoadScene("GameOver");
			return;
		}
		this.anim.SetTrigger("death");
		this.PlayerDeath.Play();
		base.StartCoroutine(this.Respawn());
		PlayerPrefs.SetInt("PlayerLives", this.lives);
		PlayerPrefs.Save();
	}

	// Token: 0x0600005C RID: 92 RVA: 0x0000303C File Offset: 0x0000123C
	public void UpdateSpawnPoint(Vector2 newSpawnPoint)
	{
		this.playerSpawnPoint.position = newSpawnPoint;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0000304F File Offset: 0x0000124F
	private IEnumerator Respawn()
	{
		this.movement.bodyType = RigidbodyType2D.Static;
		base.transform.position = this.playerSpawnPoint.position;
		this.movement.bodyType = RigidbodyType2D.Dynamic;
		yield return null;
		yield break;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0000305E File Offset: 0x0000125E
	public void GainLifeFromCoins()
	{
		this.lives++;
		PlayerPrefs.SetInt("PlayerLives", this.lives);
		PlayerPrefs.Save();
	}

	// Token: 0x04000053 RID: 83
	public int lives = 3;

	// Token: 0x04000054 RID: 84
	private Rigidbody2D movement;

	// Token: 0x04000055 RID: 85
	private Animator anim;

	// Token: 0x04000056 RID: 86
	private Vector2 initialSpawnPoint;

	// Token: 0x04000057 RID: 87
	[SerializeField]
	private Transform playerSpawnPoint;

	// Token: 0x04000058 RID: 88
	[SerializeField]
	private AudioSource PlayerDeath;
}
