using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	public Player1 test;
	int nbbomb=5;
	int puissance=5;
	int speed=5;
	float playerposx,playerposz;
	public Player1(int x, int y,int z)
	{
		this.nbbomb=x;
		this.puissance=y;
		this.speed=z;
	}
	  public int getnb()
	{
		return this.nbbomb;
	}
	  public int getpower()
	{
		return this.puissance;
	}
	  public int getspeed()
	{
		return this.speed;
	}
	public void setplayerpos()
	{
		if ((this.transform.position.x-Mathf.Floor(this.transform.position.x))>=0.5)
			playerposx=Mathf.Ceil(this.transform.position.x)+5;
		else
			playerposx=Mathf.Floor(this.transform.position.x)+5;
		if ((this.transform.position.z-Mathf.Floor(this.transform.position.z))>=0.5)
			playerposz=Mathf.Ceil(this.transform.position.z)+5;
		else
			playerposz=Mathf.Floor(this.transform.position.z)+5;
	}
	void Start () {
		test=new Player1(5,5,5);
		
	}
	void Update() {
		setplayerpos();
	}
}
