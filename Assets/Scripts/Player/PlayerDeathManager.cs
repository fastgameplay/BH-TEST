using System.Collections;
using Mirror;
using UnityEngine;
public class PlayerDeathManager : NetworkBehaviour
{
    [SerializeField] float _deathTimeInSeconds;
    private PlayerInfo _playerInfo;
    
    [SyncVar]
    public bool IsImmune;
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
        Debug.Log(IsImmune + ",expected : true ; From PlayerDeathManager First;");

        Color oldColor = _playerInfo.PlayerColor;
        _playerInfo.PlayerColor = Color.red;
        yield return new WaitForSeconds(seconds);
        _playerInfo.PlayerColor = oldColor;
        IsImmune = false;
        Debug.Log(IsImmune + ",expected : false ; From PlayerDeathManager Second;");

    }
   
}
