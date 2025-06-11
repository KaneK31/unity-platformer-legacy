using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class NPCBehavior : MonoBehaviour
{
	// Token: 0x06000056 RID: 86 RVA: 0x00002ED7 File Offset: 0x000010D7
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			this.dialogueBox.SetActive(true);
			this.speechBubble.SetActive(true);
		}
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00002EFE File Offset: 0x000010FE
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			this.speechBubble.SetActive(false);
			this.dialogueBox.SetActive(false);
		}
	}

	// Token: 0x04000051 RID: 81
	public GameObject dialogueBox;

	// Token: 0x04000052 RID: 82
	public GameObject speechBubble;
}
