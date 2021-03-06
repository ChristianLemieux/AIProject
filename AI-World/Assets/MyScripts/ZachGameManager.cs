﻿using UnityEngine;
using System.Collections;

public class ZachGameManager : MonoBehaviour {

	public int numVillagers;
	public int numWerewolves;
	public GameObject villagerPrefab;
	public GameObject werewolfPrefab;

	private int maxSpawnX, minSpawnX, maxSpawnZ, minSpawnZ;
	private int villagerSpawnPointX, villagerSpawnPointZ, villagerSpawnMod;

	// Use this for initialization
	void Start () {
		//Set up spawn boundaries for werewolves.
		maxSpawnX = 800; minSpawnX = 190;
		maxSpawnZ = 820; minSpawnZ = 190;

		//Sets up the spawn point for villager, and how far from it they can spawn.
		villagerSpawnPointX = 400; villagerSpawnPointZ = 350; villagerSpawnMod = 50;

		for (int i = 0; i < numVillagers; i++) 
		{
			//give them a random spawn loc near the spawn point.
			float spawnPosX = villagerSpawnPointX + Random.Range(-villagerSpawnMod,villagerSpawnMod);
			float spawnPosZ = villagerSpawnPointZ + Random.Range(-villagerSpawnMod,villagerSpawnMod);

			//Spawn them off the ground slightly so they dont fall through.
			GameObject.Instantiate(villagerPrefab,new Vector3(spawnPosX,3,spawnPosZ),Quaternion.identity);
		}

		for (int i = 0; i < numWerewolves; i++)
		{
			float spawnPosX = Random.Range(minSpawnX,maxSpawnX);
			float spawnPosZ = Random.Range(minSpawnZ,maxSpawnZ);

			//Spawn them off the ground slightly so they dont fall through.
			GameObject.Instantiate(werewolfPrefab,new Vector3(spawnPosX,5,spawnPosZ),Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
