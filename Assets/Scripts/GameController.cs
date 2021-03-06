using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;	
using System.IO;

public class GameController : MonoBehaviour {

	//public Slider sliderFood;
	public static GameController controller;

	private ItemTable itemList;		//Prefab with all possible items

	public int[] inventory;
	public int[] usedIndex;

	public float foodData = 0;
	public int goldData = 0;
	public int researchData = 0;
	public int suppliesData = 0;

	public StructureFarm farm;
	public StructureAcademy academy;
	public StructureWorkshop workshop;

	public HunterList listData;

	public void OnEnable(){
		// usedIndex = new int[ItemTable.keys[ItemTable.keys.Length-1] + 1];
		itemList = GetComponent<ItemTable>();
		usedIndex = ItemTable.keys;

		if (!Load ()) {
			foodData = 0;
			goldData = 0;
			researchData = 0;
			suppliesData = 0;

			Debug.Log("Size is: " + (ItemTable.keys[ItemTable.keys.Length-1] + 1));		//remove later

			// inventory = new int[itemList.Size];
			inventory = new int[ItemTable.keys[ItemTable.keys.Length-1] + 1];
			
			// while(inventory.Count < inventory.Capacity){
			// 	inventory.Add(0);
			// }
			// usedIndex = ItemTable.keys;

			listData = new HunterList();
		}
	}

	public void OnDisable(){
		Save ();
	}
	//singleton stuff
	void Awake(){
		
		Debug.Log(Application.persistentDataPath);	//remove later

		if(controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}

		else if (controller != this)
		{
			Destroy(gameObject);
		}

		// itemList = GetComponent<ItemTable>;
	}

	// Use this for initialization
	void Start () {
		// if(listData == null)
		// 	listData = new HunterList ();
		farm = new StructureFarm ();
		academy = new StructureAcademy ();
		workshop = new StructureWorkshop ();

		// OnEnable();
	}

	//---------------------------------------------------------------------------------------------------

	public void setFoodData(float n){
		foodData = n;
	}

	public void setGoldData(int n){
		goldData = n;
	}

	public void setResearchData(int n){
		researchData = n;
	}

	public void setSuppliesData(int n){
		suppliesData = n;
	}

	public float getFoodData(){
		return foodData;
	}

	public int getGoldData(){
		return goldData;
	}

	public int getResearchData(){
		return researchData;
	}

	public int getSuppliesData(){
		return suppliesData;
	}

	public void addFoodData(float n){
		foodData = foodData + n;
	}

	public void addGoldData(int n){
		goldData += n;
	}

	public void addResearchData(int n){
		researchData += n;
	}

	public void addSuppliesData(int n){
		suppliesData += n;
	}

	public void subtractFoodData(int n){
		foodData -= n;
	}

	public void subtractGoldData(int n){
		goldData -= n;
	} 	

	public void subtractResearchData(int n){
		researchData -= n;
	}

	public void subtractSuppliesData(int n){
		suppliesData -= n;
	}
	//---------------------------------------------------------------------------------------------------

	public bool assignHunter(String job, int hunterID){
		if (job == "Farmer") {
			return farm.addToList (hunterID);
		} else if (job == "Researcher") {
			return academy.addToList (hunterID);
		} else if (job == "Worker") {
			return workshop.addToList (hunterID);
		} else
			return false;
	}

	//---------------------------------------------------------------------------------------------------

	public void addHunter(){
		listData.add ();
	}

	//---------------------------------------------------------------------------------------------------

	public void Upgrade(String structure) {
		Debug.Log ("Upgrade!");
		if (structure.Equals ("Upgrade Hamlet Farm")) {
			GameController.controller.farm.levelFarm++;
			Debug.Log (GameController.controller.farm.getLevel());
		} else if (structure.Equals ("Upgrade Hamlet Academy")) {
			GameController.controller.academy.levelAcademy++;
			Debug.Log (GameController.controller.academy.getLevel());
		} else if (structure.Equals ("Upgrade Hamlet Workshop")) {
			GameController.controller.workshop.levelWorkshop++;
			Debug.Log (GameController.controller.workshop.getLevel());
		}

	}

	//---------------------------------------------------------------------------------------------------

	public void consumeFood(){
		GameController.controller.subtractFoodData (listData.Count);
		//Debug.Log (listData.Count);
		//Debug.Log (GameController.controller.foodData);
	}

	//---------------------------------------------------------------------------------------------------



	// Update is called once per frame
	float nextTime = 3.0F;
	void Update () {
		if (Time.time > nextTime) {
			nextTime += 3;
			GameController.controller.consumeFood ();

			GameController.controller.addFoodData(GameController.controller.farm.produced());
			GameController.controller.addResearchData(GameController.controller.academy.produced());
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

		Debug.Log("Save Success!");

		GameData data = new GameData();
		data.food = foodData;
		data.gold = goldData;
		data.research = researchData;
		data.supplies = suppliesData;
		data.list = new ListCast(listData);

		// data.inventory = new int[](inventory);
		data.inventory = inventory;
		// data.usedIndex = ItemTable.keys;

		Debug.Log("Count is: " + data.list.Count);

		bf.Serialize(file, data);
		file.Close();
	}

	public bool Load()
	{
		// Debug.Log (Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);

			GameData data = (GameData)bf.Deserialize(file);
			file.Close();

			foodData = data.food;
			goldData = data.gold;
			researchData = data.research;
			suppliesData = data.supplies;
			listData = new HunterList(data.list);

			// inventory = new int[](data.inventory);
			inventory = data.inventory;
			// usedIndex = data.usedIndex;

			// if(inventory.Count < itemList.Size){
			// 	// inventory = new int[itemList.Size];
			// 	Debug.Log("Load Failed!");
			// 	return false;
			// }

			Debug.Log("Load Success!");
			Debug.Log("Count is: " + data.list.Count);

			return true;
		}

		Debug.Log("Load Failed!");
		return false;
	}

}

[Serializable]
class GameData{
	public float food;
	public int gold;
	public int research;
	public int supplies;
	public ListCast list;

	public int[] inventory;
	// public int[] usedIndex;
}