using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	//Linked Classes
	public UserScore userscore;

	//configurable attributes
	public float Level1Frequency = 5f;
	public float frequencyPerlevel = 5f;
	public float timeBetweenLevels = 2f; //in seconds

	private float level = 1;

	//returns the current wave freq
	public float getFrequency()
	{
		return Level1Frequency + (level-1) * frequencyPerlevel;
	}

}