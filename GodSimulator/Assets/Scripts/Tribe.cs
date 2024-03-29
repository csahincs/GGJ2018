﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Tribe : MonoBehaviour {

    public GameObject tribeMember;
    public GameObject spawnLocation;
    public GameObject resource;
    public GameObject panel;
    public GameObject highlighter;

    public int resourceType;

    private int people = 2;
    private int food = 0;
    private int water = 0;
    private int wool = 0;
	private int tool = 0;

	private NavMeshAgent agent;

    private void Start()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = food.ToString();
        panel.transform.GetChild(1).GetComponent<Text>().text = water.ToString();
        panel.transform.GetChild(2).GetComponent<Text>().text = wool.ToString();
        panel.transform.GetChild(3).GetComponent<Text>().text = tool.ToString();
    }
    private void Update()
    {
        panel.transform.GetChild(0).GetComponent<Text>().text = food.ToString();
        panel.transform.GetChild(1).GetComponent<Text>().text = water.ToString();
        panel.transform.GetChild(2).GetComponent<Text>().text = wool.ToString();
        panel.transform.GetChild(3).GetComponent<Text>().text = tool.ToString();
    }
    public void changeFoodSupply( int changeAmount )
    {
        food += changeAmount;
    }
    public void changeWaterSupply( int changeAmount )
    {
        water += changeAmount;
    }
    public void changeWoolSupply( int changeAmount )
    {
        wool += changeAmount;
    }
    public void changeToolSupply( int changeAmount )
    {
        tool += changeAmount;
    }

    public int getFood()
    {
        return food;
    }
    public int getWater()
    {
        return water;
    }
    public int getWool()
    {
        return wool;
    }
    public int getTool()
    {
        return tool;
    }

    public void increasePopulation()
    {
        people += 1;
        Instantiate(tribeMember, spawnLocation.transform.position, spawnLocation.transform.rotation, spawnLocation.transform);
    }


    private void OnMouseDown()
    {   
		if (GameManager.instance.selectedObj == null) {
			if( food >= 20 && water >= 20  )
			{
				food -= 20;
				water -= 20;
				//wool -= 20;
				increasePopulation();
			}
		}
		else {
			agent = GameManager.instance.selectedObj.GetComponent<NavMeshAgent> ();
			agent.destination = transform.position;
			//GameManager.instance.selectedObj.GetComponent<Human> ().inputActive = true;
			GameManager.instance.selectedObj = null;
            GameManager.instance.selectedTribe = transform.gameObject;
            highlighter.SetActive(false);
		}
    }
    
}
