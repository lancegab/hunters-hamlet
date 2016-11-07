using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AssignButton : MonoBehaviour {

	// Use this for initialization
	public Text name;
	public Text hunterID;

	public void OnMouseDown (){
		Debug.Log ("IN HERE!");
		if (name.text == "F")
			GameController.controller.assignHunter ("Farmer", System.Int32.Parse (hunterID.text));
		else if (name.text == "M")
			GameController.controller.assignHunter ("Researcher", System.Int32.Parse (hunterID.text));
	}
}
