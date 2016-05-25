using UnityEngine;
using System.Collections;
using System;

public class TextSources : MonoBehaviour {

    public TextAsset text_asset;

    private string[] lines;
    private int current_line;

    private void Awake() {
        lines = text_asset.text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        current_line = 0;
    }

    private void Start () {
    }

    public string GetNextLine() {
        Debug.Log("In text sources");
        current_line += 1;
        return (lines[current_line - 1]);
    }
}
