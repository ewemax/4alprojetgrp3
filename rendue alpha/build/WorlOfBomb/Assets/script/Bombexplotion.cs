using UnityEngine;
using System.Collections;

public class Bombexplotion : MonoBehaviour {
	GameObject[,] tabc = Crealaby.tab;
	Player1 test;
	public bool n,s,e,o=true;
	public Vector3 pos;
	int x,z;
	int[,] tab;
	public int cas1;
	public int cas2;	
	float time = 0.5f;
	void Colorchanger()
	{
			this.renderer.material.color = Color.red;
	}
	void Colorchangeg()
	{
			this.renderer.material.color = Color.grey;
	}
	IEnumerator bombexplode()
	{
		x = (int)this.transform.position.x+5;
		z = (int)this.transform.position.z+5;
		test = (Player1)GameObject.Find("player1").GetComponent("Player1");
		yield return new WaitForSeconds(time);
		Colorchanger();
		yield return new WaitForSeconds(time);
		Colorchangeg();
		yield return new WaitForSeconds(time);
		Colorchanger();
		yield return new WaitForSeconds(time);
		Colorchangeg();
		yield return new WaitForSeconds(0.3f);
		Colorchanger();
		yield return new WaitForSeconds(0.3f);
		Colorchangeg();
		yield return new WaitForSeconds(0.1f);
		Colorchanger();
		yield return new WaitForSeconds(0.1f);
		Colorchangeg();
		yield return new WaitForSeconds(0.1f);
		Colorchanger();
		yield return new WaitForSeconds(0.1f);
		this.renderer.enabled=false;
		/*while(true)
		{
			
		}*/
		Destroy(this);
	}
	
	
	
	
	// Use this for initialization
	void Start () {
		StartCoroutine("bombexplode");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
