using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateGoldText : MonoBehaviour {

	public Canvas RMHud;
	public Text textGold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		textGold.text = GameController.controller.goldData.ToString();

	}
}
