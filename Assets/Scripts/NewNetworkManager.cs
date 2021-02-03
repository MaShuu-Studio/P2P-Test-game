using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public struct CharPropertyMessage : NetworkMessage
{
    public int id;
}
public class NewNetworkManager : NetworkManager
{
    [Header("Additive Object")]
    [SerializeField] GameController gameController;
    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CharPropertyMessage>(CreateCharacter);
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        CharPropertyMessage charMessage = new CharPropertyMessage
        {
            id = 0
        };

        conn.Send(charMessage);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        gameController.RemoveColor(conn.connectionId);        
        NetworkServer.DestroyPlayerForConnection(conn);
    }

    private void CreateCharacter(NetworkConnection conn, CharPropertyMessage msg)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab);
        Character character = player.GetComponent<Character>();
        Color c = gameController.GetColor(conn.connectionId);
        character.SetColor(c);

        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
