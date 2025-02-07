using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    public StationController stationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pass the player's Collider to the StationController
            stationController.OnPlayerEnterStation(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if station is complete
            if (stationController.CanPlayerLeave())
            {
                stationController.OnPlayerExitStation();
            }
            else
            {
                Debug.Log("Station is not complete yet! The wall should still block exit.");
            }
        }
    }
}
