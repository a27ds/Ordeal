using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject Player;
    public GameObject Logo;
    public GameObject startButton;
    public List<Transform> playerWaypoints;
    public List<Transform> ghostWaypoints;
    public float GhostMoveSpeed = 5.0f;
    public float playerMoveSpeed = 2.0f;
    int ghostRandomSpawnIndex;
    int ghostLastRandomWaypointIndex;
    int waypointIndex;
    GameObject newGhost;
    GameObject newPlayer;

    void Start()
    {
        SpawnGhostOnWaypoint();
        SpawnPlayerOnWaypoint();
        MoveGhost();
        MovePlayer();
        LayoutTheLoadingWindow();
    }

    void LayoutTheLoadingWindow()
    {
        Vector3 logoPos = Camera.main.ScreenToWorldPoint(new Vector3(50, 50, 10));
        Vector3 startButtonPos = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.screenWidth - 50, GameManager.screenHeight / 2, 10));
        Logo.transform.position = logoPos;
        startButton.transform.position = startButtonPos;
    }

    void SpawnPlayerOnWaypoint()
    {
        newPlayer = Instantiate(Player, playerWaypoints[0].transform);
    }

    void MovePlayer()
    {
        if (waypointIndex == 5)
        {
            waypointIndex = 0;
        }
        else
        {
            waypointIndex++;
        }
        LeanTween.move(newPlayer, playerWaypoints[waypointIndex].position, playerMoveSpeed).setEaseLinear().setOnComplete(MovePlayer);
    }

    void SpawnGhostOnWaypoint()
    {
        ghostRandomSpawnIndex = GhostRandomWayPoint();
        newGhost = Instantiate(Ghost, ghostWaypoints[ghostRandomSpawnIndex].transform);
        ghostLastRandomWaypointIndex = ghostRandomSpawnIndex;
    }

    void MoveGhost()
    {
        LeanTween.move(newGhost, ghostWaypoints[GhostRandomWayPoint()].position, GhostMoveSpeed).setEaseInOutCubic().setOnComplete(MoveGhost);
    }

    int GhostRandomWayPoint()
    {
        bool sameIndex = true;
        while (sameIndex)
        {
            int randomIndex = Random.Range(0, ghostWaypoints.Count);
            if (randomIndex != ghostLastRandomWaypointIndex)
            {
                sameIndex = false;
                return randomIndex;
            }
        }
        return 0;
    }
}
