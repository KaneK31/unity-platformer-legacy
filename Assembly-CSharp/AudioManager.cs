using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class AudioManager : MonoBehaviour
{
	// Token: 0x0600003E RID: 62 RVA: 0x00002C81 File Offset: 0x00000E81
	private void Start()
	{
		this.audioSource = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002C8F File Offset: 0x00000E8F
	public void PlayEnemyDieSound()
	{
		this.audioSource.clip = this.EnemyDieSound;
		this.audioSource.Play();
	}

	// Token: 0x0400003E RID: 62
	private AudioSource audioSource;

	// Token: 0x0400003F RID: 63
	public AudioClip EnemyDieSound;
}
