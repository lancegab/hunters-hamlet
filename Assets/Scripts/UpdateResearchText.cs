using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateResearchText : MonoBehaviour {

	public Canvas RMHud;
	public Text textResearch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		textResearch.text = GameController.controller.researchData.ToString();

	}
}
