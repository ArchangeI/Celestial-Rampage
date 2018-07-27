using UnityEngine;
using System.Collections;

public class RobotSpawn : MonoBehaviour {

	[SerializeField]
	GameObject[] robots;

	private int timesSpawned;
	private int healthBonus = 0;

	public void SpawnRobot() {
	  timesSpawned++;
	  healthBonus += 1 * timesSpawned;
	  GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
	  robot.transform.position = transform.position;
	  robot.GetComponent<Robot>().health += healthBonus;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
