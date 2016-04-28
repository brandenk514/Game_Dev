using UnityEngine;
using System.Collections;


public class comp_cs : MonoBehaviour {
	
	Transform Spine0,Spine1,Spine2,Spine3,Spine4,Spine5,Neck0,Neck1,Neck2,Neck3,Head,Jaw,
	Tail0,Tail1,Tail2,Tail3,Tail4,Tail5,Tail6,Tail7,Tail8,Arm1,Arm2;
	float turn,pitch,pitch2,open,balance,temp,velocity,jumpforce,animcount, Scale = 0.0F;
	bool reset,soundplayed;
	string infos;
	Animator anim;
	public Texture[] skin,eyes;
	public AudioClip Smallstep,Comp_Roar1,Comp_Roar2,Comp_Call1,Comp_Call2,Comp_Jump,Bite;
	public float startTimer = 0f;
	public int tripCount;
	public bool tripped, jump,isdead = false;
	private bool keysLocked = false;

	void Awake ()
	{
		Tail0 = this.transform.Find ("Comp/root/pelvis/tail0");
		Tail1 = this.transform.Find ("Comp/root/pelvis/tail0/tail1");
		Tail2 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2");
		Tail3 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3");
		Tail4 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3/tail4");
		Tail5 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3/tail4/tail5");
		Tail6 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3/tail4/tail5/tail6");
		Tail7 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3/tail4/tail5/tail6/tail7");
		Tail8 = this.transform.Find ("Comp/root/pelvis/tail0/tail1/tail2/tail3/tail4/tail5/tail6/tail7/tail8");
		Spine0 = this.transform.Find ("Comp/root/spine0");
		Spine1 = this.transform.Find ("Comp/root/spine0/spine1");
		Spine2 = this.transform.Find ("Comp/root/spine0/spine1/spine2");
		Spine3 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3");
		Spine4 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4");
		Spine5 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5");
		Arm1 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/left arm0");
		Arm2 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/right arm0");
		Neck0 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0");
		Neck1 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0/neck1");
		Neck2 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0/neck1/neck2");
		Neck3 = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0/neck1/neck2/neck3");
		Head = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0/neck1/neck2/neck3/head");
		Jaw = this.transform.Find ("Comp/root/spine0/spine1/spine2/spine3/spine4/spine5/neck0/neck1/neck2/neck3/head/jaw0");
	
		anim = GetComponent<Animator> ();

	}

	void OnCollisionEnter(Collision collision )
	{
		if (collision.gameObject.CompareTag ("Ground")) {
			anim.SetBool ("Onground", true);
			jump = true;
		}
	}
		
	void Update ()
	{

		if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			keysLocked = true;
		} else {
			keysLocked = false;
		}
		//***************************************************************************************
		//Moves animation controller


		//Attack animation controller
		/*if (Input.GetKey (KeyCode.Mouse0) && Input.GetKey (KeyCode.LeftShift)) anim.SetInteger ("Attack", 2);
		else if (Input.GetKey (KeyCode.Mouse0)) anim.SetInteger ("Attack", 1);
		else anim.SetInteger ("Attack", 0);*/

		if (Input.GetKey (KeyCode.Space) &&
		    !anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|JumpLoop") &&
		    !anim.GetNextAnimatorStateInfo (0).IsName ("Comp|JumpLoop") &&
		    !anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|JumpLoopAttack") &&
		    !anim.GetNextAnimatorStateInfo (0).IsName ("Comp|JumpLoopAttack") &&
		    !anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandJumpDown") &&
		    !anim.GetNextAnimatorStateInfo (0).IsName ("Comp|StandJumpDown") &&
		    !anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunJumpDown") &&
		    !anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunJumpDown")) {
			anim.SetBool ("Onground", false);
			jump = true; //Jump
		}
		/*else if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) anim.SetInteger ("State", 4); //Run
		else if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.W)) anim.SetInteger ("State", 3); //Steps
		else if (Input.GetKey (KeyCode.W)) anim.SetInteger ("State", 1); //Walk
		else if (Input.GetKey (KeyCode.S)) anim.SetInteger ("State", -1); //Steps Back*/
		if (!jump) {
			if (Input.GetKey (KeyCode.A) && !keysLocked)
				anim.SetInteger ("State", 2); //Strafe+
			else if (Input.GetKey (KeyCode.D)&& !keysLocked)
				anim.SetInteger ("State", -2); //Strafe-
		}
		//else if (Input.GetKey (KeyCode.LeftControl)) anim.SetInteger ("State", -4); //Steps Idle
		else if (tripped) {
			anim.SetInteger ("State", 1);
		} else if (isdead) {
			anim.SetBool ("isDead", true);
		}

		else {
			if (Time.time - startTimer < 3f) {
				anim.SetInteger ("Idle", 1);
			} else {
				anim.SetInteger ("State", 4);
			}
		}
			
		//Reset spine position
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|SleepLoop") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Die") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandB") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandC") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|EatA") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|EatB") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandEat") ||
		    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|GroundAttack")
		   ) reset = true; else reset = false;


		//Reset position
		if (balance != 0.0F)
		{
			if (balance < 0.0F)
			{
				if (balance < -0.3F)
					balance += 0.3F;
				else
					balance = 0.0F; 
			}
			else if (balance > 0.0F)
			{
				if (balance > 0.3F)
					balance -= 0.3F;
				else
					balance = 0.0F; 
			}
		}

	}



	//***************************************************************************************
	//Clamp and set bone rotations
	void LateUpdate()
	{
			balance = Mathf.Clamp (balance, -7.5F, 7.5F);
			
			if (anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Run") ||
			    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Run") ||
			    anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunGrowl") ||
			    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunGrowl"))
			{
				turn = Mathf.Clamp (turn, -7.5F, 7.5F);
				pitch = Mathf.Clamp (pitch, 0.0F, 9.0F);
				pitch2 = Mathf.Clamp (pitch2, -20.0F, 0.0F);
			}
			else
			{
				turn = Mathf.Clamp (turn, -15.5F, 15.5F);
				pitch = Mathf.Clamp (pitch, 0.0F, 9.0F);
				pitch2 = Mathf.Clamp (pitch2, -40.0F, 0.0F);
			}
			
			open = Mathf.Clamp (open, -40.0F, 0.0F);
			temp = turn - balance;
			temp += turn;
			temp = Mathf.Clamp (temp, -15.5F, 15.5F);
			
			//Spine left/right
			Spine0.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Spine1.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Spine2.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Spine3.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Spine4.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Spine5.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			
			Neck0.transform.localRotation *= Quaternion.AngleAxis (temp * 2, new Vector3 (0, 0, -1));
			Neck1.transform.localRotation *= Quaternion.AngleAxis (temp * 2, new Vector3 (0, 0, -1));
			Neck2.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			Neck3.transform.localRotation *= Quaternion.AngleAxis (temp / 2, new Vector3 (0, 0, -1));
			Head.transform.localRotation *= Quaternion.AngleAxis (temp, new Vector3 (0, 0, -1));
			
			//Turning
			Tail0.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail1.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail2.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail3.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail4.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail5.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail6.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail7.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));
			Tail8.transform.localRotation *= Quaternion.AngleAxis (balance, new Vector3 (0, 0, -1));

			//Jaw
			Jaw.transform.localRotation *= Quaternion.AngleAxis (open, new Vector3 (-1, 0, 0));
			
			//Spine up/down
			Spine0.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Spine1.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Spine2.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Spine3.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Spine4.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Spine5.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Neck0.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Neck1.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Neck2.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Neck3.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			Head.transform.localRotation *= Quaternion.AngleAxis (pitch, new Vector3 (-1, 0, 0));
			
			//Neck up/down
			Spine0.transform.localRotation *= Quaternion.AngleAxis (pitch2, new Vector3 (-1, 0, 0));
			Arm1.transform.localRotation *= Quaternion.AngleAxis (-pitch2, new Vector3 (-1, 0, 0));
			Arm2.transform.localRotation *= Quaternion.AngleAxis (-pitch2, new Vector3 (0, -1, 0));
			Neck0.transform.localRotation *= Quaternion.AngleAxis (pitch2, new Vector3 (-1, 0, 0));
			Neck1.transform.localRotation *= Quaternion.AngleAxis (pitch2, new Vector3 (-1, 0, 0));
			Head.transform.localRotation *= Quaternion.AngleAxis (-pitch2, new Vector3 (-1, 0, 0));
	}

	
//***************************************************************************************
//Model translations and rotations
void FixedUpdate ()
{
		//adjust speed to the model's scale
		Scale = this.transform.localScale.x;
		//adjust gravity to the model's scale
		Physics.gravity = new Vector3(0, -Scale*60.0f, 0);


		//Walking
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Walk") ||
		    	 anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Walk"))

		{
			if(Input.GetKey(KeyCode.A) && !keysLocked)
			{
				transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
				balance += 0.5F;
			}
			else if(Input.GetKey(KeyCode.D)&& !keysLocked)
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
				balance -= 0.5F;
			}


			if (velocity < 0.2F)
			{
				velocity = velocity + (Time.deltaTime * 0.5F); //acceleration
			}
			else if (velocity > 0.2F)
			{
				velocity = velocity - (Time.deltaTime * 0.5F); //acceleration
			}
			
			this.transform.Translate (0, 0, velocity*Scale);
		}

			else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Walk-") ||
			    anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Walk-"))
				
			{
			if(Input.GetKey(KeyCode.D) && !keysLocked)
				{
					transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
					balance += 0.5F;
				}
			else if(Input.GetKey(KeyCode.A) && !keysLocked)
				{
					this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
					balance -= 0.5F;
				}
				
				
				if (velocity < 0.2F)
				{
					velocity = velocity + (Time.deltaTime * 0.5F); //acceleration
				}
				else if (velocity > 0.2F)
				{
					velocity = velocity - (Time.deltaTime * 0.5F); //acceleration
				}
				
			this.transform.Translate (0, 0, -velocity*Scale);
			}


		//Running
		else if (anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Run") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Run") ||
			     anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunGrowl") ||
			     anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunGrowl") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunAttackA") ||
		         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunAttackA") ||
			     anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunAttackB") ||
			     anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunAttackB") ||
		         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunJumpDown") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunJumpDown"))
		{
			if(Input.GetKey(KeyCode.A) && !keysLocked)
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
				balance += 0.5F;
			}
			else if(Input.GetKey(KeyCode.D) && !keysLocked)
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
				balance -= 0.5F;
			}
			
			if (velocity < 0.4F)
			{
				velocity = velocity + (Time.deltaTime * 2.5F);
			}
			
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunAttackA") &&
			    anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 0.8) velocity =0.0F;

				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunAttackB") && velocity > 0.2F)
					velocity = velocity - (Time.deltaTime * 2.5F);
			
			
			this.transform.Translate (0, 0, velocity*Scale);
		}


		//Strafe-
		else if (anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Strafe-") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Strafe-"))
		{
			if (Input.GetKey(KeyCode.Mouse1))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (turn, new Vector3 (0, 1, 0));
			}
			
			if (velocity < 0.1F)
			{
				velocity = velocity + (Time.deltaTime * 0.5F); //acceleration
			}
			else if (velocity > 0.1F)
			{
				velocity = velocity - (Time.deltaTime * 0.5F); //acceleration
			}
			
			this.transform.Translate (velocity*Scale,0,0);
		}


		//Strafe+
		else if ( anim.GetNextAnimatorStateInfo (0).IsName ("Comp|Strafe+") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|Strafe+"))
		{
			if (Input.GetKey(KeyCode.Mouse1))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (turn, new Vector3 (0, 1, 0));
			}
			
			if (velocity < 0.1F)
			{
				velocity = velocity + (Time.deltaTime * 0.5F); //acceleration
			}
			else if (velocity > 0.1F)
			{
				velocity = velocity - (Time.deltaTime * 0.5F); //acceleration
			}
			
			this.transform.Translate (-velocity*Scale,0,0);
		}
		

		//Stand jump
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandJumpUp") ||
			anim.GetNextAnimatorStateInfo (0).IsName ("Comp|StandJumpUp"))
		{
			anim.SetBool("Onground", false);
			
			if(anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 0.5 && jumpforce<0.5F )
				jumpforce = jumpforce + (Time.deltaTime * 10.0F);
			
			this.transform.Translate (0,jumpforce*Scale, 0);
		}


		//Running jump
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunJumpUp") ||
		         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunJumpUp"))
		{
			anim.SetBool("Onground", false);

			if(Input.GetKey(KeyCode.A) && !keysLocked)
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
				balance += 0.5F;
			}
			else if(Input.GetKey(KeyCode.D) && !keysLocked)
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
				balance -= 0.5F;
			}

			if(anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 0.5F && jumpforce<0.5F)
			{
				jumpforce = jumpforce + (Time.deltaTime * 10.0F);
			}

			if (velocity < 0.2F)
			{
				velocity = velocity + (Time.deltaTime * 10.0F);
			}

			this.transform.Translate (0,jumpforce*Scale, velocity*Scale);
		}


		//Jump loop
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|JumpLoop") ||
			         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|JumpLoop") ||
			     anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|JumpLoopAttack") ||
			         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|JumpLoopAttack"))
		{

			if(Input.GetKey(KeyCode.A))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
				balance += 0.5F;
			}
			else if(Input.GetKey(KeyCode.D))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
				balance -= 0.5F;
			}

			if (jumpforce > 0.0F)
			{
				jumpforce = jumpforce - (Time.deltaTime * 2.0F);
			}

			if (velocity > 0.0F)
			{
				velocity = velocity - (Time.deltaTime * 0.01F);
			}

			this.transform.Translate (0, jumpforce*Scale, velocity*Scale);
		}


		//Jump landing
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandJumpDown") ||
		         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|StandJumpDown") ||
		         anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunJumpDown") ||
		         anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunJumpDown"))
		{

			jumpforce =0.0F;

			if(Input.GetKey(KeyCode.A))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
				balance += 0.5F;
			}
			else if(Input.GetKey(KeyCode.D))
			{
				this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
				balance -= 0.5F;
			}

			if (velocity < 0.2F &&
			    anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|RunJumpDown") ||
			    anim.GetNextAnimatorStateInfo (0).IsName ("Comp|RunJumpDown"))
			{
				velocity = velocity + (Time.deltaTime * 2.5F);
			}
			else velocity =0.0F;

			this.transform.Translate (0, jumpforce*Scale, velocity*Scale);
		}


		//Jump Attack
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|JumpAttack"))
		{
			if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime > 0.4 && anim.GetCurrentAnimatorStateInfo (0).normalizedTime < 0.9)
			{

				if(Input.GetKey(KeyCode.A))
				{
					this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, -1, 0));
					balance += 0.5F;
				}
				else if(Input.GetKey(KeyCode.D))
				{
					this.transform.localRotation *= Quaternion.AngleAxis (2.0F, new Vector3 (0, 1, 0));
					balance -= 0.5F;
				}


				if (velocity < 0.2F)
				{
					velocity = velocity + (Time.deltaTime * 5.0F);
				}
			} else velocity = 0.0F;
			
			this.transform.Translate (0, 0, velocity*Scale);
		}


		//Stop
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Comp|StandA"))
				{
					velocity =0.0F;
					this.transform.Translate (0, 0, velocity*Scale);
				}
}


	
	
	
	
	
	
	
	
	
	
}




