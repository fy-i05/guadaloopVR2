using UnityEngine;
using System.Collections;

public class StationController : MonoBehaviour
{
    [SerializeField] private float requiredStayTime = 5f;  // how long before station is "complete"
    private bool stationCompleted = false;
    private bool isPlayerInside = false;
    private float timer = 0f;

    // Called by StationTrigger when player enters
    public void OnPlayerEnterStation()
    {
        Debug.Log("Player entered station area.");
        isPlayerInside = true;
        timer = 0f;  // reset timer
    }

    // Called by StationTrigger if the station allows them to leave
    public void OnPlayerExitStation()
    {
        Debug.Log("Player left station area.");
        isPlayerInside = false;
    }

    // StationTrigger calls this to see if the player can leave without a warning
    public bool CanPlayerLeave()
    {
        return stationCompleted;
    }

    private void Update()
    {
        // If player is inside and not completed, count time
        if (isPlayerInside && !stationCompleted)
        {
            timer += Time.deltaTime;
            if (timer >= requiredStayTime)
            {
                stationCompleted = true;
                Debug.Log("Station tasks complete! Player can now leave freely.");
            }
        }
    }
}
