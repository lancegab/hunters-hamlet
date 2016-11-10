using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Upgradable : MonoBehaviour{
	// public int itemID;

	public int[] recipe;			//tells count of those at item index
	public int[] usedIndexes;		//tells item at index

	/*
	Visualization

	index		[0][1][4]
	recipe		[2][2][1]
	
	At i = 0, you need 2 counts of Item found at ItemTable[0]
	At i = 1, you need 2 counts of Item found at ItemTable[1]
	At i = 2, you need 2 counts of Item found at ItemTable[4]
	*/

	public void OnEnable(){
	}

	public Upgradable(){
	}
	
	public bool isUpgradable(){
		for(int i = 0; i < usedIndexes.Length; i++){
			if(GameController.controller.inventory[usedIndexes[i]] < recipe[i])	//checks if there's enough materials
				return false;
		}
		return true;
	}

	public void upgrade(){
		/*
			Level++ here
		*/
	}

}