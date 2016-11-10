using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour{
	public int itemID;

	public bool craftable;
	public Craftable craftingRecipe;

	public void OnEnable(){
		if (craftable)
			craftingRecipe = GetComponent<Craftable>();
	} 
}