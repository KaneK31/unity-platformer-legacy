using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class GameManager : MonoBehaviour
{
	// Token: 0x0600004A RID: 74 RVA: 0x00002DCA File Offset: 0x00000FCA
	private void OnApplicationQuit()
	{
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x0400004B RID: 75
	[SerializeField]
	private PlayerLife playerLife;
}
