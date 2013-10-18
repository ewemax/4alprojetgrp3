using UnityEngine;
using System.Collections;

public class Crealaby : MonoBehaviour {
	
	public GameObject indes;
	public GameObject des;
	public GameObject bomb;
	bool iscreate=false;
	static public GameObject[,] tab = new GameObject[11,11];
	float num;
	// Use this for initialization
	void Start () {
		 
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a"))
		{
			if (iscreate==false)
				{
				for (int i=0;i<=10;i++)
				{
					for (int j=0;j<11;j++)
					{
						num = Random.Range(0f,1f);
						if ((i%2!=0) && (j%2!=0))
						{
							
							tab[i,j] = (GameObject)Instantiate(indes,new Vector3(-5f+i,0.5f,-5f+j),Quaternion.identity);
							
						}
						else 
							if(num>=0.15f)
								{
									
									tab[i,j] = (GameObject)Instantiate(des,new Vector3(-5f+i,0.5f,-5f+j),Quaternion.identity);
									
							
								}
					}
				}
				
				if(tab[0,0]!=null)
					Destroy(tab[0,0]);
				if(tab[0,1]!=null)
					Destroy(tab[0,1]);
				if(tab[1,0]!=null)
					Destroy(tab[1,0]);
				if(tab[0,10]!=null)
					Destroy(tab[0,10]);
				if(tab[0,9]!=null)
					Destroy(tab[0,9]);
				if(tab[1,10]!=null)
					Destroy(tab[1,10]);
				if(tab[10,10]!=null)
					Destroy(tab[10,10]);
				if(tab[10,9]!=null)
					Destroy(tab[10,9]);
				if(tab[9,10]!=null)
					Destroy(tab[9,10]);
				if(tab[10,0]!=null)
					Destroy(tab[10,0]);
				if(tab[10,1]!=null)
					Destroy(tab[10,1]);
				if(tab[9,0]!=null)
					Destroy(tab[9,0]);
			}
			iscreate=true;
		}
		
	}
}
