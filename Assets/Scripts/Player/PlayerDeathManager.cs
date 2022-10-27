using System.Collections;
using Mirror;
using UnityEngine;
public class PlayerDeathManager : NetworkBehaviour
{
    [SyncVar]
    public bool IsImmune;
    [SerializeField] float _deathTimeInSeconds;
    PlayerInfo _playerInfo;


    void OnDrawGizmosSelected () {
        if (_deathTimeInSeconds < 0) {
            _deathTimeInSeconds = 0;
        }
    }


    void Awake(){
        IsImmune = false;
        _playerInfo = GetComponent<PlayerInfo>();
    }

    [Command(requiresAuthority = false)] // <3
    public void Hit(){
        if(IsImmune == false){
            IsImmune = true;
            StartCoroutine(HitCorutine(_deathTimeInSeconds));
        }
    }

    IEnumerator HitCorutine(float seconds){

        Color oldColor = _playerInfo.PlayerColor;
        _playerInfo.PlayerColor = Color.red;
        yield return new WaitForSeconds(seconds);
        _playerInfo.PlayerColor = oldColor;
        IsImmune = false;

    }
   
}
