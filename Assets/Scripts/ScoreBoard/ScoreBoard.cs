using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour{
    [SerializeField] private int _maxScore;
    [SerializeField] private Text _scoreBoardText;

    List<PlayerInfo> _playerInfos;
    public void Refresh(){
        string scoreBoardStr = "";
        for (int i = 0; i < _playerInfos.Count; i++){
            scoreBoardStr += _playerInfos[i].PlayerName + " : " + _playerInfos[i].PlayerScore.ToString() + " \n";
        }
        _scoreBoardText.text = scoreBoardStr;
        Debug.Log("Refreshed");
    }
    public void AddPlayer(PlayerInfo playerInfo){
        _playerInfos.Add(playerInfo);
        Refresh();
    }

}
