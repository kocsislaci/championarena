using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingletonBehaviour<GameManager>
{
    [Header("Players")]
    public GameObject redPlayerToSpawn;
    public GameObject bluePlayerToSpawn;
    private Tuple<GameObject, GameObject> _players;
    [Header("Spawn Points")]
    [SerializeField]
    private GameObject redSpawnPoint;
    [SerializeField]
    private GameObject blueSpawnPoint;
    [Header("Camera")]
    [SerializeField]
    private CameraController cameraController;
    
    private PlayerInput PlayerInput
    {
        get
        {
            if (_playerInput == null)
            {
                _playerInput = GetComponent<PlayerInput>();
            }
            return _playerInput;
        }
    }
    private PlayerInput _playerInput;
    
    private void OnValidate()
    {
        if (redPlayerToSpawn == null || bluePlayerToSpawn == null)
        {
            throw new Exception("Red or Blue players are not set.");
        }
        if (redPlayerToSpawn.GetComponent<PlayerController>() == null ||
            bluePlayerToSpawn.GetComponent<PlayerController>() == null)
        {
            throw new Exception("Red or Blue players are set to non-playable gameObjects.");
        }
    }

    protected override void Awake()
    {
        base.Awake();
        SpawnPlayers();
        SetUpPlayers();
        cameraController.SetTargets(_players);
    }
    
    private void SpawnPlayers()
    {
        _players = new Tuple<GameObject, GameObject>(
            Instantiate(redPlayerToSpawn, redSpawnPoint.transform.position, new Quaternion()),
            Instantiate(bluePlayerToSpawn, blueSpawnPoint.transform.position, new Quaternion())
            );
    }

    private void SetUpPlayers()
    {
        _players.Item1.name = "RedPlayer";
        _players.Item1.GetComponent<PlayerController>().Init(Color.red, PlayerInput);
        _players.Item1.GetComponent<DamageableBehaviour>().die.AddListener(GameOver);
        _players.Item2.name = "BluePlayer";
        _players.Item2.GetComponent<PlayerController>().Init(Color.blue, PlayerInput);
        _players.Item2.GetComponent<DamageableBehaviour>().die.AddListener(GameOver);
    }

    private void GameOver(PlayerController loser)
    {
        Debug.Log($"Game over, Loser is: {loser.PlayerColor}.");
    }

    // TODO: gameState management
    
    // public readonly Dictionary<Color, string> PathToLoadActionMap = new ()
    // {
    //     { Color.red, "Controls/PlayerInputActionsMap" },
    //     { Color.blue, "Controls/PlayerInputActionsMap" },
    // };
}
