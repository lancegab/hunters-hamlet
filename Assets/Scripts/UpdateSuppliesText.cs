using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateSuppliesText : MonoBehaviour {

	public Canvas RMHud;
	public Text textSupplies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		textSupplies.text = GameController.controller.suppliesData.ToString();

	}
}
