using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int Level_number { get; set; }

    public float Level_points { get; set; }

    public int Level_stars { get; set; }

    public bool Level_completed { get; set; }

    public int Achivs { get; set; }
    public int Level_numberOfCombo { get; set; }
    public int Level_longestCombo { get; set; }
    

    public Level(int level_number, float level_points, int level_stars, bool level_completed, int achivs, int level_numberOfCombo, int level_longestCombo )
    {
        this.Level_number = level_number;
        this.Level_points = level_points;
        this.Level_stars = level_stars;
        this.Level_completed = level_completed;
        this.Achivs = achivs;
        this.Level_numberOfCombo = level_numberOfCombo;
        this.Level_longestCombo = level_longestCombo;
    }


}
