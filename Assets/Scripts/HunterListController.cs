using UnityEngine;
using System.Collections;

public class HunterListController : MonoBehaviour {

	public static HunterListController hlcontroller;
	//public Sprite [] AnimalImages;
	public GameObject ContentPanel;
	public GameObject ListItemPrefab;
	public GameObject contentPrefab;
	GameObject newContent;
	void Awake(){
		if(hlcontroller == null)
		{
			DontDestroyOnLoad(gameObject);
			hlcontroller = this;
		}

		else if (hlcontroller != this)
		{
			Destroy(gameObject);
		}
	}

	void Start () {

		// 2. Iterate through the data, 
		//	  instantiate prefab, 
		//	  set the data, 
		//	  add it to panel
		//newContent = Instantiate(contentPrefab) as GameObject;
		//newContent.transform.parent = ContentPanel.transform;
		//newContent.transform.SetParent(ContentPanel.transform);
		//newContent.transform.localScale = Vector2.one;

	}

	public void addHunterToUI(GameObject newContent, Hunter hunter){
		Debug.Log ("IN");
		GameObject newHunter = Instantiate(ListItemPrefab) as GameObject;
		HunterListItemController controller= newHunter.GetComponent<HunterListItemController>();
		//controller.Icon.sprite = animal.Icon;
		controller.hunterID.text = hunter.hunterID.ToString();
		controller.hunterName.text = hunter.Name;
		controller.farmingLvl.value = hunter.farmingLvl;
		controller.researchLvl.value = hunter.researchLvl;
		controller.huntingLvl.value = hunter.huntingLvl;
		newHunter.transform.parent = newContent.transform;
		newHunter.transform.localScale = Vector3.one;
		newHunter.transform.localPosition = Vector3.one;
	}

	public void displayHunters(string structureName){
		newContent = Instantiate(contentPrefab) as GameObject;
		newContent.transform.parent = ContentPanel.transform;
		newContent.transform.localScale = Vector3.one;
		newContent.transform.localPosition = Vector3.one;

		if (structureName == "Hamlet Hall") {
			foreach (Hunter hunter in GameController.controller.listData.hunterList) {
				addHunterToUI (newContent, hunter);
			}
		} else if (structureName == "Farm") {
			foreach (int hunterID in GameController.controller.farm.farmerList) {
				addHunterToUI (newContent, GameController.controller.listData.find(hunterID));
			}
		} else if (structureName == "Academy") {
			foreach (int hunterID in GameController.controller.academy.researcherList) {
				addHunterToUI (newContent, GameController.controller.listData.find(hunterID));
			}
		} else if (structureName == "Workshop") {
			foreach (int hunterID in GameController.controller.workshop.workerList) {
				addHunterToUI (newContent, GameController.controller.listData.find(hunterID));
			}
		}
	}

	public void closeDisplay(){
		Destroy (newContent);
	}
}