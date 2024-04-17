using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;

    private GameObject spawnedPlayer;

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            int randomNumber = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomNumber];

            GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerIcon"]];
            spawnedPlayer = PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
            SetCameraTarget(spawnedPlayer.transform);
        }
    }

    private void SetCameraTarget(Transform target)
    {
        cameraFollow cameraScript = Camera.main.GetComponent<cameraFollow>();
        if (cameraScript != null)
        {
            cameraScript.SetTarget(target);
        }
    }
}
