using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(GameRestart))]
public class ScoreBoard : NetworkBehaviour{
    [SyncVar(hook = nameof(OnScoreBoardChanged))]
    public string ScoreBoardStr = "";
    public ScoreBoardRefrence scoreBoardRefrence; 
    [SerializeField] int _maxScore;
    [SerializeField] Text _scoreBoardText;

    
    List<PlayerInfo> _playerInfos = new List<PlayerInfo>();
    bool isGameOver = false;
    public void Refresh(){
        if(isGameOver) return;

        string tempBoardStr = "";

        for (int i = 0; i < _playerInfos.Count; i++){
            tempBoardStr += _playerInfos[i].PlayerName + " : " + _playerInfos[i].PlayerScore.ToString() + " \n";
            if(_playerInfos[i].PlayerScore == _maxScore){
                GetComponent<GameRestart>().EndGame(_playerInfos[i].PlayerName);
                tempBoardStr = "";
                isGameOver = true;
                break;

            }
        }
        ScoreBoardStr = tempBoardStr;
    }
    void OnScoreBoardChanged(string _Old, string _New){
        _scoreBoardText.text = _New;
    }
    public void AddPlayer(PlayerInfo playerInfo){
        _playerInfos.Add(playerInfo);
        Refresh();
        
    }

}
