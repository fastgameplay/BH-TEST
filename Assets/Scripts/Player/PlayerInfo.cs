using System.Collections;
using Mirror;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour{
    [SyncVar]
    public string PlayerName;

    [SyncVar(hook = nameof(OnColorChanged))]
    public Color PlayerColor = Color.white;

    [SyncVar(hook = nameof(OnScoreChanged))]
    public int PlayerScore = 0;
    [SerializeField] private MeshRenderer _playerModelMesh;
    private int _id;

    void OnColorChanged(Color _Old, Color _New){
        _playerModelMesh.material.color = _New;
    }

    void OnScoreChanged(int _Old, int _New){
        if(_New == 3) Debug.Log("GAMEOVER");
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
