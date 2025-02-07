using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    public StationController stationController;

    private void OnTriggerEnter(Collider other)
    {
        // If the object entering has the "Player" tag, call OnPlayerEnterStation
        if (other.CompareTag("Player"))
        {
            stationController.OnPlayerEnterStation();
            // Hide warning if it was shown
            UIManager.Instance.ShowWarningPanel(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the object exiting has the "Player" tag, check if station is complete
        if (other.CompareTag("Player"))
        {
            if (stationController.CanPlayerLeave())
            {
                // If allowed, call OnPlayerExitStation
                stationController.OnPlayerExitStation();
            }
            else
            {
                // Station not complete => show red overlay
                Debug.Log("Station not complete yet! Showing warning.");
                UIManager.Instance.ShowWarningPanel(true);
            }
        }
    }
}
