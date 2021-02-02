using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameController : NetworkBehaviour
{
    [SerializeField] List<Material> mats;
    [SerializeField] GameObject charac;
    private List<int> clients;
    private List<bool> mat_Indexes;

    private int cons = 0;

    void Start()
    {
        mat_Indexes = new List<bool>();
        clients = new List<int>();

        for(int i = 0; i < mats.Count; i++)
        {
            mat_Indexes.Add(false);
        }

        for(int i = 0; i < clients.Count; i++)
        {
            clients.Add(-1);
        }
    }

    void Update()
    {
        
    }
    
    public Material SetColor()
    {
        for(int i = 0; i < mats.Count; i++)
        {
            if (mat_Indexes[i] == false)
            {
                mat_Indexes[i] = true;
                return mats[i];
            }
        }

        return null;
    }

    public void RemoveColor(Material mat)
    {
        for(int i = 0; i < mats.Count; i++)
        {
            if (mats[i] == mat)
            {
                mat_Indexes[i] = false;
                break;
            }
        }
    }
}
