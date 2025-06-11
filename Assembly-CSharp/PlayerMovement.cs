using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class PlayerMovement : MonoBehaviour
{
	// Token: 0x06000060 RID: 96 RVA: 0x00003092 File Offset: 0x00001292
	private void Start()
	{
		this.movement = base.GetComponent<Rigidbody2D>();
		this.coll = base.GetComponent<BoxCollider2D>();
		this.Animation = base.GetComponent<Animator>();
		this.character = base.GetComponent<SpriteRenderer>();
		this.movement = base.GetComponent<Rigidbody2D>();
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000030D0 File Offset: 0x000012D0
	private void Update()
	{
		this.direction = Input.GetAxis("Horizontal");
		if (Input.GetKey(KeyCode.A))
		{
			this.movement.velocity = new Vector2(-this.PlayerSpeed, this.movement.velocity.y);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			this.movement.velocity = new Vector2(this.PlayerSpeed, this.movement.velocity.y);
		}
		else
		{
			this.movement.velocity = new Vector2(this.direction * this.PlayerSpeed, this.movement.velocity.y);
		}
		if (Input.GetButtonDown("Jump") && this.Grounded())
		{
			this.jumpFX.Play();
			this.movement.velocity = new Vector2(this.movement.velocity.x, this.JumpHeight);
		}
		if (this.direction > 0f)
		{
			this.wallCheck.localPosition = new Vector2(Mathf.Abs(this.wallCheck.localPosition.x), this.wallCheck.localPosition.y);
		}
		else if (this.direction < 0f)
		{
			this.wallCheck.localPosition = new Vector2(-Mathf.Abs(this.wallCheck.localPosition.x), this.wallCheck.localPosition.y);
		}
		this.UpdateAnimations();
		this.WallSlide();
		this.WallJump();
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00003268 File Offset: 0x00001468
	private void UpdateAnimations()
	{
		PlayerMovement.MovementAnim movementAnim;
		if (this.direction > 0f)
		{
			movementAnim = PlayerMovement.MovementAnim.running;
			this.character.flipX = false;
		}
		else if (this.direction < 0f)
		{
			movementAnim = PlayerMovement.MovementAnim.running;
			this.character.flipX = true;
		}
		else
		{
			movementAnim = PlayerMovement.MovementAnim.idle;
		}
		if (this.movement.velocity.y > 0.1f)
		{
			movementAnim = PlayerMovement.MovementAnim.jumping;
		}
		else if (this.movement.velocity.y < -0.1f)
		{
			movementAnim = PlayerMovement.MovementAnim.falling;
		}
		this.Animation.SetInteger("state", (int)movementAnim);
	}

	// Token: 0x06000063 RID: 99 RVA: 0x000032F8 File Offset: 0x000014F8
	private bool Grounded()
	{
		return Physics2D.BoxCast(this.coll.bounds.center, this.coll.bounds.size, 0f, Vector2.down, 0.1f, this.JumpAgain);
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00003359 File Offset: 0x00001559
	private bool IsWalled()
	{
		return Physics2D.OverlapCircle(this.wallCheck.position, 0.2f, this.wallLayer);
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00003388 File Offset: 0x00001588
	private void WallSlide()
	{
		if (this.IsWalled() && !this.Grounded() && this.direction != 0f)
		{
			this.IsWallSlidig = true;
			this.movement.velocity = new Vector2(this.movement.velocity.x, Mathf.Clamp(this.movement.velocity.y, -this.slideSpeed, float.MaxValue));
			return;
		}
		this.IsWallSlidig = false;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00003404 File Offset: 0x00001604
	private void WallJump()
	{
		if (this.IsWallSlidig)
		{
			this.isWallJumping = false;
			this.wallJumpingCounter = this.wallJumpTime;
		}
		else
		{
			this.wallJumpingCounter -= Time.deltaTime;
		}
		float num = (this.character.flipX ? (-1f) : 1f);
		if (Input.GetButtonDown("Jump") && this.wallJumpingCounter > 0f)
		{
			this.isWallJumping = true;
			this.movement.velocity = new Vector2(num * this.wallJumpPower.x, this.wallJumpPower.y);
			this.wallJumpingCounter = 0f;
		}
		if (base.transform.localScale.x != num)
		{
			this.isWallJumping = !this.isWallJumping;
			base.transform.localScale = new Vector3(Mathf.Abs(base.transform.localScale.x), base.transform.localScale.y, base.transform.localScale.z);
		}
		base.Invoke("StopWallJump", this.wallJumpingDuration);
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00003528 File Offset: 0x00001728
	private void StopWallJump()
	{
		this.isWallJumping = false;
		Vector3 localScale = base.transform.localScale;
		localScale.x = Mathf.Abs(localScale.x);
		base.transform.localScale = localScale;
	}

	// Token: 0x04000059 RID: 89
	private Rigidbody2D movement;

	// Token: 0x0400005A RID: 90
	private BoxCollider2D coll;

	// Token: 0x0400005B RID: 91
	private Animator Animation;

	// Token: 0x0400005C RID: 92
	private SpriteRenderer character;

	// Token: 0x0400005D RID: 93
	[SerializeField]
	private LayerMask JumpAgain;

	// Token: 0x0400005E RID: 94
	private float direction;

	// Token: 0x0400005F RID: 95
	private float PlayerSpeed = 8f;

	// Token: 0x04000060 RID: 96
	private float JumpHeight = 20f;

	// Token: 0x04000061 RID: 97
	private bool IsWallSlidig;

	// Token: 0x04000062 RID: 98
	private float slideSpeed = 2f;

	// Token: 0x04000063 RID: 99
	private bool isWallJumping;

	// Token: 0x04000064 RID: 100
	private float wallJumpDir;

	// Token: 0x04000065 RID: 101
	[SerializeField]
	private float wallJumpTime = 0.2f;

	// Token: 0x04000066 RID: 102
	private float wallJumpingCounter;

	// Token: 0x04000067 RID: 103
	private float wallJumpingDuration = 0.4f;

	// Token: 0x04000068 RID: 104
	[SerializeField]
	private Vector2 wallJumpPower = new Vector2(8f, 16f);

	// Token: 0x04000069 RID: 105
	[SerializeField]
	private Transform wallCheck;

	// Token: 0x0400006A RID: 106
	[SerializeField]
	private LayerMask wallLayer;

	// Token: 0x0400006B RID: 107
	[SerializeField]
	private AudioSource jumpFX;

	// Token: 0x02000028 RID: 40
	private enum MovementAnim
	{
		// Token: 0x0400008A RID: 138
		idle,
		// Token: 0x0400008B RID: 139
		running,
		// Token: 0x0400008C RID: 140
		jumping,
		// Token: 0x0400008D RID: 141
		falling
	}
}
