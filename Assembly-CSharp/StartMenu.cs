using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000018 RID: 24
public class StartMenu : MonoBehaviour
{
	// Token: 0x0600004E RID: 78 RVA: 0x00002E32 File Offset: 0x00001032
	public void StartGame()
	{
		SceneManager.LoadScene("Level 1");
	}
}
