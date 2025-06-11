using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000019 RID: 25
public class LevelComplete : MonoBehaviour
{
	// Token: 0x06000050 RID: 80 RVA: 0x00002E46 File Offset: 0x00001046
	private void Start()
	{
		this.StartingSceneTran.SetActive(true);
		base.Invoke("DisableStartSceneTran", 5f);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002E64 File Offset: 0x00001064
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Player" && !this.FinishCheck)
		{
			this.FinishCheck = true;
			this.RunEndingSceneTransition();
		}
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002E92 File Offset: 0x00001092
	private void DisableStartSceneTran()
	{
		this.StartingSceneTran.SetActive(false);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002EA0 File Offset: 0x000010A0
	private void RunEndingSceneTransition()
	{
		this.EndingSceneTran.SetActive(true);
		base.StartCoroutine(this.TransitionAfterDelay(3f));
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002EC0 File Offset: 0x000010C0
	private IEnumerator TransitionAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		yield break;
	}

	// Token: 0x0400004E RID: 78
	[SerializeField]
	private GameObject StartingSceneTran;

	// Token: 0x0400004F RID: 79
	[SerializeField]
	private GameObject EndingSceneTran;

	// Token: 0x04000050 RID: 80
	private bool FinishCheck;
}
