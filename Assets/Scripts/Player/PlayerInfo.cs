using System.Collections;
using Mirror;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour{
    [SerializeField] private MeshRenderer _playerModelMesh;

    public string PlayerName;

    [SyncVar(hook = nameof(OnColorChanged))]
    public Color PlayerColor = Color.white;


    void OnColorChanged(Color _Old, Color _New)
    {
        _playerModelMesh.material.color = _New;
    }

    public override void OnStartLocalPlayer(){
        string name = "Player" + Random.Range(0, 100);
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        CmdSetupPlayer(name, color);
    }

    [Command]
    public void CmdSetupPlayer(string _name, Color _col){
        PlayerName = _name;
        PlayerColor = _col;
    }
}
