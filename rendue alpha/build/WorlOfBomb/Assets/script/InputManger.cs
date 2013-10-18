using UnityEngine;
using System.Collections;

public class InputManger : MonoBehaviour 
{


    public GameObject _Joueur1;
    public GameObject _Joueur2;
    public GameObject bomb;
    public GameObject plan;
    public string _ip="127.0.0.1";

    public int port = 4242;
    public bool _serverBuild;

    public float _walk_speed = 4.0f;

    private Transform _Joueur1Transform;
    private Transform _Joueur2Transform;
    private Transform _PlanTransform;

    private Vector3 _currentJ1Direction = Vector3.zero;
    private Vector3 _currentJ2Direction = Vector3.zero;
    private Vector2 _currentPlanDirection = Vector3.zero;

    private NetworkPlayer _J1;
    private NetworkPlayer _J2;
    private NetworkPeerType _Plane;



    /*
     * Crealaby
     * 
     */
    public GameObject indes;
    public GameObject des;
    //public GameObject bomb;
    bool iscreate = false;
    static public GameObject[,] tab = new GameObject[11, 11];
    float num;

	// Use this for initialization
	void Start () 
    {

        Application.runInBackground = true;

        if (_serverBuild)
        {
            Network.InitializeSecurity();
            Network.InitializeServer(2, port, true);
        }
        else
        {
            Network.Connect(_ip, port);
        }
        if (Network.isServer)
        {
            _Joueur1Transform = _Joueur1.transform;
            _Joueur2Transform = _Joueur2.transform;
            //_PlanTransform = plan.transform;
        }
	}

    void OnConnectedToServer()
    {
        print("Que la partie commence!!!");
    }

    void OnPlayerConnected(NetworkPlayer Joueur)
    {
        if (Network.connections.Length == 1)
        {
            _J1 = Joueur;
        }

        if (Network.connections.Length == 2)
        {
            _J2 = Joueur;

           
        }

    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Network.isServer)
        {
            MoveJoueur(_Joueur1Transform, _currentJ1Direction);
            MoveJoueur(_Joueur1Transform, _currentJ2Direction);
            //_PlanTransform.position += _currentPlanDirection * _walk_speed * Time.deltaTime;//MoveJoueur
           // MoveJoueur(_PlanTransform, _currentPlanDirection);

            if (Input.GetKeyDown("a")||Input.GetKey(KeyCode.Q))
            {
                if (iscreate == false)
                {
                    for (int i = 0; i <= 10; i++)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            num = Random.Range(0f, 1f);
                            if ((i % 2 != 0) && (j % 2 != 0))
                            {
                                
                                tab[i, j] = (GameObject)Instantiate(indes, new Vector3(-5f + i, 0.5f, -5f + j), Quaternion.identity);
                                Network.Instantiate(tab[i, j], new Vector3(-5f + i, 0.5f, -5f + j), Quaternion.identity, 0);
                            }
                            else
                                if (num >= 0.15f)
                                {

                                    tab[i, j] = (GameObject)Instantiate(des, new Vector3(-5f + i, 0.5f, -5f + j), Quaternion.identity);
                                    Network.Instantiate(tab[i, j], new Vector3(-5f + i, 0.5f, -5f + j), Quaternion.identity, 0);

                                }
                        }
                    }

                    if (tab[0, 0] != null)
                        Destroy(tab[0, 0]);
                    if (tab[0, 1] != null)
                        Destroy(tab[0, 1]);
                    if (tab[1, 0] != null)
                        Destroy(tab[1, 0]);
                    if (tab[0, 10] != null)
                        Destroy(tab[0, 10]);
                    if (tab[0, 9] != null)
                        Destroy(tab[0, 9]);
                    if (tab[1, 10] != null)
                        Destroy(tab[1, 10]);
                    if (tab[10, 10] != null)
                        Destroy(tab[10, 10]);
                    if (tab[10, 9] != null)
                        Destroy(tab[10, 9]);
                    if (tab[9, 10] != null)
                        Destroy(tab[9, 10]);
                    if (tab[10, 0] != null)
                        Destroy(tab[10, 0]);
                    if (tab[10, 1] != null)
                        Destroy(tab[10, 1]);
                    if (tab[9, 0] != null)
                        Destroy(tab[9, 0]);
                }
                iscreate = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.networkView.RPC("ClientBeginMoveDown", RPCMode.Server, Network.player);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                this.networkView.RPC("ClientStopMove", RPCMode.Server, Network.player);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.networkView.RPC("ClientBeginMoveUp", RPCMode.Server, Network.player);
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.networkView.RPC("ClientStopMove", RPCMode.Server, Network.player);
            }
           /* if (Input.GetKeyDown("space"))
            {
                this.networkView.RPC("ClientPoseBomb", RPCMode.Server, Network.player);
            }*/
        }
	}

    [RPC]
    void ClientBeginMoveUp(NetworkPlayer Joueur)
    {
        if (Network.isServer)
        {
            if (Joueur == _J1)
                _currentJ1Direction = Vector3.up;
            if (Joueur == _J2)
                _currentJ2Direction = Vector3.up;
        }
    }

    [RPC]
    void ClientBeginMoveDown(NetworkPlayer Joueur)
    {
        if (Joueur == _J1)
            _currentJ1Direction = Vector3.down;
        if (Joueur == _J2)
            _currentJ2Direction = Vector3.down;
    }

    [RPC]
    void ClientStopMove(NetworkPlayer Joueur)
    {
        if (Joueur == _J1)
            _currentJ1Direction = Vector3.zero;
        if (Joueur == _J2)
            _currentJ2Direction = Vector3.zero;
    }

    [RPC]
    void ClientPoseBomb(NetworkPlayer Joueur)
    {
       // if (Joueur == _J2)
       //     _currentJ2Direction = Vector3.zero;
       // GameObject bombs = (GameObject)Instantiate(bomb, posbomb(this.transform.position), Quaternion.identity);
    }

    void MoveJoueur(Transform transform, Vector3 direction)
    {
        transform.position += direction * _walk_speed * Time.deltaTime;
    }
}
