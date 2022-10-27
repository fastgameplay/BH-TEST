using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class GameRestart : NetworkBehaviour{
    [SerializeField] Text _winnerText;
    [SerializeField] float _showWinnerSeconds;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake(){
        _winnerText.gameObject.SetActive(false);
    }
    public void EndGame(string winner, ScoreBoard scoreBoard){
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        _winnerText.text = "WINNER : " + winner;
        StartCoroutine(GameOverCourutine());

    }
    IEnumerator GameOverCourutine(){
        _winnerText.gameObject.SetActive(false);
        yield return new WaitForSeconds(_showWinnerSeconds);
        NetworkManager.singleton.ServerChangeScene("MainScene");
    }
}
