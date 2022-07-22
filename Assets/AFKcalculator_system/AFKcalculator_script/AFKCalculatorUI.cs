using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AFKCalculatorUI : MonoBehaviour
{
	public Button monsterButton;
	public Button islandButton;

	public AFKCalculator AFKCalculator;

	public TextMeshProUGUI monsterText;
	public TextMeshProUGUI islandText;

	void Start()
	{
		AFKCalculator = FindObjectOfType<AFKCalculator>();
		
		Button monsterBut = monsterButton.GetComponent<Button>();
		monsterBut.onClick.AddListener(MonsterButOnClick);

		Button islandBut = islandButton.GetComponent<Button>();
		islandBut.onClick.AddListener(IslandButOnClick);


	}

	void MonsterButOnClick()
	{
		AFKCalculator.MonsterCal();
		monsterText.text = AFKCalculator.monsterText;
	}

	void IslandButOnClick()
	{
		AFKCalculator.LandCal();
		islandText.text = AFKCalculator.islandText;
	}


}

