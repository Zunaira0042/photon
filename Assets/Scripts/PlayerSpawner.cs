using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined {
    public GameObject _player;
    public void PlayerJoined(PlayerRef player) {
        if (player == Runner.LocalPlayer) {
        Runner.Spawn(_player,new Vector3(Random.Range(0,3),1,0),Quaternion.identity);
        }
    }
}
