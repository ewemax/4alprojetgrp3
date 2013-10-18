using UnityEngine;
using System.Collections;

public class InputController1 : MonoBehaviour {
	Player1 test,caca;
	public int bombnb=1;
    int _walk_speed = 4;
	int power,nbmax;
	public GameObject bomb;
	Vector3 posbomb(Vector3 pos)
	{
		float x,z;
		if ((pos.x-Mathf.Floor(pos.x))>=0.5)
			x=Mathf.Ceil(pos.x);
		else
			x=Mathf.Floor(pos.x);
		if ((pos.z-Mathf.Floor(pos.z))>=0.5)
			z=Mathf.Ceil(pos.z);
		else
			z=Mathf.Floor(pos.z);
		return new Vector3(x,0.5f,z);
	}
	void Start () {
		test= (Player1)GameObject.Find("player1").GetComponent("Player1");
		//caca = new Playerclass(test.getpower(),test.getnb(),test.getspeed());
		_walk_speed=test.test.getspeed();
	}
	
    void Update()
    {
		
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z + _walk_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z - _walk_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x - _walk_speed * Time.deltaTime,
                this.transform.position.y,
                this.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = new Vector3(
                this.transform.position.x + _walk_speed * Time.deltaTime,
                this.transform.position.y,
                this.transform.position.z);
        }
		if (Input.GetKeyDown("space"))
		{
			if(bombnb<=test.test.getnb())
			{
				GameObject bombs = (GameObject) Instantiate(bomb,posbomb(this.transform.position),Quaternion.identity);
				bombnb+=1;
			}
			
		}
    }
}
