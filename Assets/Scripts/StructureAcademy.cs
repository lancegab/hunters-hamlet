using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class StructureAcademy : MonoBehaviour {

	//public static structureAcademy academy;
	public List<int> researcherList;
	public int levelAcademy;
//	public Canvas RMHud;
//	public Text textResearch;

	public StructureAcademy(){
		researcherList = new List<int>();
		levelAcademy = 1;
	}
	//singleton stuff
	/*void Awake(){
		if(academy == null)
		{
			DontDestroyOnLoad(gameObject);
			academy = this;
		}

		else if (academy != this)
		{
			Destroy(gameObject);
		}
	}*/

	// Use this for initialization
	void Start () {

		GameController.controller.setResearchData (101);
		Debug.Log (GameController.controller.researchData);
	
	//	textResearch.text = GameController.controller.researchData.ToString();

		/*
		 *String hunterList;
		 *for
		 *	hunterList = hunterlist + " " + hunter.name + " " + level + "\n"

		  textBox.text = hunterList
		*/

	
	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() 
	{
		print ("clicked");
	}

	public int countHunterLevel(){

		int lvl = 0;
		foreach (int hunterID in GameController.controller.academy.researcherList) {
			lvl += GameController.controller.listData.find (hunterID).ResearchLvl;
		}

		return lvl;
	}

	public int produced(){
		int r = countHunterLevel ();

		Debug.Log ("r " + r);
		return r;
	}

	public int getLevel(){
		return levelAcademy;
	}

	public int getCount(){
		return researcherList.Count;
	}

	public bool addToList(int id){
		if (researcherList.Count < getLevel () * 3) {
			researcherList.Add (id);
			return true;
		} else
			return false;
	}
}
