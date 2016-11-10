using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemTable : MonoBehaviour{
	// public static ItemTable tableInstance = null;
	public static int[] keys = {0,1,4};		//keys are indexes for existing items, those not listed are considered non-existent

	/*
	Note: Since Dictionaries seem to be a bit complicated with Editors we'll
	use indexing for keys of items.

	[0]		->		Stick
	[1]		->		Wooden Stick

	[4]		->		Stone Sword

	*/

	[SerializeField]
	private int tableSize;		//size refers to the last used index+1

	[SerializeField]
	private int[] keyValues = keys;

	

	public GameObject[] itemList;



	void Awake()
	{
		/*
		//Check if instance already exists
		if (tableInstance == null)
			tableInstance = this;		//if not, set instance to this

		//If instance already exists and it's not this:
		else if (tableInstance != this)
			Destroy(gameObject);	//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.  

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		*/

	}


	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

	public int Size{			//gets size of inventory
		get{
			return tableSize;
		}
	}

	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//

	public static bool validIndex(int index){
		for(int i = 0; i < keys.Length; i++){
			if(index == keys[i])
				return true;
		}

		return false;
	}
}