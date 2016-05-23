using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArrowCounter : MonoBehaviour {

    public string base_text = "Bow strings: ";

    private Text my_text;
    private Archer my_archer;

	void Start () {
        my_text = gameObject.GetComponent<Text>();
        my_archer = FindObjectOfType<Archer>();
	}
	
	void Update () {
        int current_bowstring_count = my_archer.GetBowstringCount();
        my_text.text = base_text + current_bowstring_count.ToString();
	}
}
