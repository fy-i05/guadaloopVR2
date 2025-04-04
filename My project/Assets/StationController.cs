using UnityEngine;

public class StationController : MonoBehaviour
{
    private bool stationCompleted = false;

    // Called by StationTrigger when player enters (optional)
    public void OnPlayerEnterStation()
    {
        Debug.Log("Player entered station area.");
    }

    // Called by StationTrigger when the station allows them to leave (optional)
    public void OnPlayerExitStation()
    {
        Debug.Log("Player left station area.");
    }

    // The ButtonPressCounter script will call this once the user has pressed enough times
    public void MarkStationComplete()
    {
        if (!stationCompleted)
        {
            stationCompleted = true;
            Debug.Log("Station tasks complete! Player can now leave freely.");
        }
    }

    // StationTrigger calls this to see if the user can exit the station without warning
    public bool CanPlayerLeave()
    {
        return stationCompleted;
    }
}
