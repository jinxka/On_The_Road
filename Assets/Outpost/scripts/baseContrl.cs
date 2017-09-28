using UnityEngine;
using System.Collections;

public class baseContrl : MonoBehaviour {


	public static baseContrl Instance;
	Animator aniComp;
	public GameObject[] effect;
	public bool isCreate1 =false;
	public bool isCreate2 =false;

	void Awake()
	{
		Instance = this;
	}
	// Use this for initialization
	void Start () {
	

		aniComp = transform.GetComponentInChildren <Animator> ();

	}
	
	// Update is called once per frame
	void Update () {


		AnimatorStateInfo aniIN = aniComp.GetCurrentAnimatorStateInfo (0);


		if(aniIN.IsName("atk1"))
		{
			if(aniIN.normalizedTime>0.4f && aniIN.normalizedTime<0.5f)
			{
				CreaetEffect (0);			
			}
		}

		if(aniIN.IsName("atk2"))
		{
			if(aniIN.normalizedTime>0.4f && aniIN.normalizedTime<0.5f)
			{
				CreaetEffect (1);			
			}
		}

		if(aniIN.IsName("skill1"))
		{
			if(aniIN.normalizedTime>0.2f && aniIN.normalizedTime<0.3f)
			{
				if(isCreate1)
				{
					SpawnEffect (2,new Vector3(-0.5f,0.2f,0.2f));	
					isCreate1 = false;

				}
			}			
		}
		if(aniIN.IsName("idle"))
		{
			isCreate1 = true;
			isCreate2 = true;
		}

		if(aniIN.IsName("skill2"))
		{
			if(aniIN.normalizedTime>0.01f && aniIN.normalizedTime<0.2f)
			{
				if(isCreate2)
				{

					SpawnEffect (3,new Vector3(-0.5f,-0.8f,-2.2f));	
					isCreate2 = false;

				}
			}

		}


//		if(aniIN.IsName("skill3_2"))
//		{
//			
//			if(aniIN.normalizedTime>0.01f && aniIN.normalizedTime<0.3f)
//			{
//				
//				CreaetEffect (5);			
//			}
//		}

//		if(!aniIN.IsName("skill3_2"))
//		{
//
//			if (effect [5].activeInHierarchy)
//				deActiveEffect (5);
//
//		}



//		if (!aniIN.IsName ("skill4"))
//		{
//			if (effect [6].activeInHierarchy)
//				deActiveEffect (6);
////			isCreate1 = false;
////			isCreate2 =false;
//		}

//		if(aniIN.IsName("skill5"))
//		{
//			if(aniIN.normalizedTime>0.47f && aniIN.normalizedTime<0.6f)
//			{
//				CreaetEffect (8);			
//			}
//		}
//
//		if(aniIN.IsName("skill6"))
//		{
//			if(aniIN.normalizedTime>0.3f && aniIN.normalizedTime<0.4f)
//			{
//				CreaetEffect (9);			
//			}
//		}
//



	}




	public  void  SpawnEffect(int id,Vector3 pos)
	{
		GameObject dd =  Instantiate (effect [id], this.transform.position+pos, Quaternion.identity) as GameObject;
	}





	public void  deActiveEffect(int id)
	{

		effect [id].SetActive (false);
	}



	public void CreaetEffect(int id)
	{
		switch(id)
		{
		case 0:
			
			effect [id].SetActive (true);
			break;
		case 1:

			effect [id].SetActive (true);
			break;
		case 2:

			effect [id].SetActive (true);
			break;


		case 3:

			effect [id].SetActive (true);
			break;
		case 4:

			effect [id].SetActive (true);
			break;
		case 5:

			effect [id].SetActive (true);
			break;

		case 6:

			effect [id].SetActive (true);
		//	GameObject dd =  Instantiate (effect [id], this.transform.position, Quaternion.identity) as GameObject;
			break;
		case 7:

			effect [id].SetActive (true);
			break;
		case 8:

			effect [id].SetActive (true);
			break;
		case 9:
			effect [id].SetActive (true);
			break;
			default :;break;
		}
	}



	public void SetAnimation(int id)  //play the animation
	{
		switch(id)
		{
		case 1:	
			aniComp.Play ("idle");
			break;
		case 2:	
			aniComp.Play ("run");	
			break;
		case 3:
			aniComp.Play ("hurt");
			break;
		case 4:	
			aniComp.Play ("die");
			break;
		case 5:	
			aniComp.Play ("atk1");
			break;
		case 6:	
			aniComp.Play ("skill1");
			break;
		case 7:
			aniComp.Play ("skill2");
			break;
		case 8:
			aniComp.Play ("skill3_1");
			break;
		case 9:				
			aniComp.Play ("skill4");
			break;
		case 10:				
			aniComp.Play ("skill5");
			break;
		case 11:				
			aniComp.Play ("skill6");
			break;
		case 12:	
			aniComp.Play ("atk2");
			break;
		case 13:	
			aniComp.Play ("swim");
			break;
		case 14:	
			aniComp.Play ("floating");
			break;
		case 15:	
			aniComp.Play ("skill1_1");
			break;
		case 16:	
			aniComp.Play ("jump");
			break;

		default :aniComp.Play ("idle");
			;break;
		}
	}
}
