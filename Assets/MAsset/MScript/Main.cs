using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	public Main() { _Instance = this;}
	public static Main Instance { get{ return _Instance; } }
	private static Main _Instance;


	[SerializeField] List<GameObject> Images;
	[SerializeField] float SwitchTime = 1f;
	[SerializeField] GameObject TempRoot;
	// Use this for initialization
	void Awake () 
	{
		StartCoroutine(SwitchImageCall());
	}

	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator SwitchImageCall()
	{
		while(true)
		{
			SwitchImage();
			yield return new WaitForSeconds(SwitchTime);
		}
	}

	void SwitchImage()
	{
		for ( int i = 0 ; i < Images.Count -1 ; ++i )
		{
			if ( Images[i].activeSelf )
			{
				Images[i].SetActive(false);
				Images[i+1].SetActive(true);
				Debug.Log("set!!!");
				return ;
			}
		}
		if ( Images[Images.Count-1].activeSelf )
		{
			Images[Images.Count-1].SetActive(false);
			Images[0].SetActive(true);
			Debug.Log("set last!!!");
		}
		Debug.Log("Switch");
	}

	public GameObject GetTemperImage()
	{
		for ( int i = 0 ; i < Images.Count ; ++i )
		{
			if ( Images[i].activeSelf )
			{
				return Images[i];
			}
		}
		return null;
	}

	public GameObject GetTempRoot()
	{
		return TempRoot;
	}
}
