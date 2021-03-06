using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class HoverStructure : MonoBehaviour , IPointerEnterHandler {

    //public GameObject dBox;
	//public GameObject hList;
	//public GameObject fList;
	//public GameObject aList;
	//public GameObject wlist;
	//public GameObject content;
	public Text title;
    public string structureName;
	//public Text upgradeTitle;
	//GameObject newPanel;
	public GameObject tooltipPanel;
	public GameObject structure;
	//public GameObject hbox;
	//public GameObject fbox;
	//public GameObject abox;
	//public GameObject wbox;
	//public GameObject content;


	#region IPointerEnterHandler implementation
	  
	public void OnPointerEnter (PointerEventData eventData)
	{
//		content.SetActive (true);
//		HunterListController.hlcontroller.displayHunters ();
		title.text = structureName;
		tooltipPanel.transform.localScale = Vector3.one;
		if (structureName == "Hamlet Hall") {
			tooltipPanel.transform.localPosition = new Vector3 (structure.transform.position.x * 400, structure.transform.position.y * 100, structure.transform.position.z);
		} else {
			tooltipPanel.transform.localPosition = new Vector3 (structure.transform.position.x * 200, structure.transform.position.y * 100, structure.transform.position.z);
		}
		Debug.Log ("STRUCT X: " + structure.transform.position.x);
		tooltipPanel.SetActive (true);
		TooltipContentController.tcontroller.displayContent (structureName);

		//tooltipPanel.transform.localPosition = Vector3.one;

/*		if(!structureName.Equals("Hamlet Hall"))
			upgradeTitle.text = "Upgrade " + structureName;
		else
			upgradeTitle.text = "Upgrade";*/
	//	HunterListController.getHunterListUI ();
	}

	public void OnMouseExit()
	{
		TooltipContentController.tcontroller.closeDisplay ();
		tooltipPanel.SetActive (false);
	}

	#endregion

	// Use this for initialization
	void Awake () {
	    
	}
	/*
	void OnMouseDown () {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			
		}
	}*/
}
