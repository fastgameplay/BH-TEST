using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class GameRestart : NetworkBehaviour{
    [SyncVar(hook = nameof(OnWinnerTextChanged))]
    public string WinnerString;

    [SerializeField] Text _winnerText;
    [SerializeField] float _showWinnerSeconds;

    void OnWinnerTextChanged(string _Old, string _New){
        _winnerText.gameObject.SetActive(true);
        _winnerText.text = _New;
    }

    public void EndGame(string winner){
        WinnerString = "WINNER : " + winner;
        StartCoroutine(GameOverCourutine());
    }
    IEnumerator GameOverCourutine(){
        yield return new WaitForSeconds(_showWinnerSeconds);
        NetworkManager.singleton.ServerChangeScene("MainScene");
    }
}
