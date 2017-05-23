using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    private string[] level;

    public void SetupScene(string[] level)
	{
        this.level = level;
    }
}
