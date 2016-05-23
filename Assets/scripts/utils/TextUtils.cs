using UnityEngine;
using System.Collections;

public static class TextUtils {

    public static string GenerateVisualText(string target_text, string typed_text) {

        // Generates rich colorized string based on type text compared
        // to target string

        string green_tag = "<color=\"#009900\">{0}</color>";
        string red_tag = "<color=\"#990000\">{0}</color>";
        string yellow_tag = "<color=\"#999900\">{0}</color>";

        string visual_text = "";
        string add_char;

        for (int i = 0; i < target_text.Length; i++) {

            string target_char = target_text.Substring(i, 1);

            if (i < typed_text.Length) {

                string typed_char = typed_text.Substring(i, 1);

                if (target_char == typed_char) {
                    add_char = string.Format(green_tag, target_char);
                }
                else {
                    add_char = string.Format(red_tag, target_char);
                }
            }
            else if (i == typed_text.Length) {
                if (target_char == " ") {
                    add_char = string.Format(yellow_tag, "_");
                }
                else {
                    add_char = string.Format(yellow_tag, target_char);
                }
            }
            else {
                add_char = target_char;
            }

            visual_text += add_char;
        }

        return visual_text;
    }
}
