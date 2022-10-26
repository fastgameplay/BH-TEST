using System.Collections;
using Mirror;
using UnityEngine;
public class PlayerDeathManager : NetworkBehaviour
{
    [SerializeField] float _deathTimeInSeconds;
    private PlayerInfo _playerInfo;
    private bool _isDead;
    
    void OnDrawGizmosSelected () {
        if (_deathTimeInSeconds < 0) {
            _deathTimeInSeconds = 0;
        }
    }


    void Awake(){
        _isDead = false;
        _playerInfo = GetComponent<PlayerInfo>();
    }
    public void Hit(){
        if(!_isDead){
            StartCoroutine(HitCorutine(_deathTimeInSeconds));
        }
    }

    IEnumerator HitCorutine(float Seconds){
        _isDead = true;
        Color oldColor = _playerInfo.PlayerColor;
        _playerInfo.PlayerColor = Color.red;
        yield return new WaitForSeconds(Seconds);
        _playerInfo.PlayerColor = oldColor;
        _isDead = false;
    }
   
}
