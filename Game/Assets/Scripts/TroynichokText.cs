using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroynichokText : MonoBehaviour
{
    private int TroynichokCount = 0;
    TMPro.TextMeshProUGUI textLabel;

	private void Awake()
	{
		textLabel = this.GetComponent<TMPro.TextMeshProUGUI>();		
	}

    public void AddTroynichok()
	{
        TroynichokCount++;
		textLabel.text = TroynichokCount.ToString();
	}
}
