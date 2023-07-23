using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamScript : MonoBehaviour
{
    protected Callback<GameOverlayActivated_t> _gameOverlayActivated;
    
    private CallResult<NumberOfCurrentPlayers_t> _numberPfCurrentPlayers;

    private void OnEnable()
    {
        if (SteamManager.Initialized)
        {
            _gameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
            // _numberPfCurrentPlayers = Callback<NumberOfCurrentPlayers_t>.Create(OnNumberOfCurrentPlayers);
        }
    }

    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);
        }
    }

    private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
    {
        if (pCallback.m_bActive != 0)
        {
            Debug.Log("Steam Overlay has beed activate");
        }
        else
        {
            Debug.Log("Steam Overlay been closed");
        }
    }
    
    private void OnNumberOfCurrentPlayers(NumberOfCurrentPlayers_t pCallback, bool bIOFailure)
    {
        if (pCallback.m_bSuccess != 1 || bIOFailure)
        {
            Debug.Log("There was an error retrieving the NumberOfCurrentPlayers");
        }
        else
        {
            Debug.Log("The number of players playing your game: " + pCallback.m_cPlayers);
        }
    }
}
