using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboShow : MonoBehaviour {
    
    Dictionary<int, int> combo = new Dictionary<int, int>()
    {{1,4},
        {2,4 },
        {3,2 }

    };
    public Text comboText1;
    public Text comboText2;
    public Text comboAmount;
    public Text comboLongest;
    string text;
	void Start () {
        comboAmount.text = "" + DrugsStat.numberOfCombo;
        comboLongest.text = "" + DrugsStat.longestCombo;
        combo = DrugsStat.comboKilled;
    }
	
	// Update is called once per frame
	void Update ()
    {
        comboText1.text = SetData1(combo);
        comboText2.text = SetData2(combo);
    }

    public string SetData1(Dictionary<int, int> pairs)
    {
        text = "Number of Combo\n";
        foreach (var item in pairs)
        {
            text += "\t" + item.Key + "\n";
        }
        return text;
    }

    public string SetData2(Dictionary<int, int> pairs)
    {
        text = "Combo\n";
        foreach (var item in pairs)
        {
            text += "\t"+ item.Value + "\n";
        }
        return text;
    }
}
