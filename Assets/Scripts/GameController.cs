using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    [SerializeField] List<Material> mats;
    [SerializeField] GameObject charac;
    private List<int> mat_clients;

    private int cons = 0;

    void Start()
    {
        mat_clients = new List<int>();

        for(int i = 0; i < mats.Count; i++)
            mat_clients.Add(-1);
    }

    public Color GetColor(int id)
    {
        for(int i = 0; i < mats.Count; i++)
        {
            if (mat_clients[i] == -1)
            {
                mat_clients[i] = id;
                return mats[i].color;
            }
        }

        return new Color(255,0,0);
    }

    public void RemoveColor(int id)
    {
        for(int i = 0; i < mat_clients.Count; i++)
        {
            if (mat_clients[i] == id)
            {
                mat_clients[i] = -1;
                break;
            }
        }
    }
}
