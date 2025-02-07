using UnityEngine;
using System.Collections;

public class StationController : MonoBehaviour
{
    [Header("Reference to the wall GameObject (with a non-trigger CapsuleCollider)")]
    [SerializeField] private GameObject stationWall;

    [Header("Time to wait before enabling the wall (seconds)")]
    [SerializeField] private float delayBeforeWall = 2f;

    // (Optional) if you want a completion timer, you can add it here:
    //[SerializeField] private float requiredStayTime = 5f;

    private bool stationCompleted = false;
    private bool isPlayerInside = false;

    // We'll store the player's Collider so we can ignore collisions briefly
    private Collider playerCollider;

    // Called by StationTrigger when player enters
    // "other" is the player's Collider
    public void OnPlayerEnterStation(Collider other)
    {
        Debug.Log("Player entered station area.");

        // Track that the player is inside
        isPlayerInside = true;
        stationCompleted = false;  // reset if needed

        // Store the player's collider for later ignoring collisions
        playerCollider = other;

        // Start the coroutine that waits 2 seconds, then raises the wall
        StartCoroutine(RaiseWallAfterDelay());
    }

    // Called by StationTrigger when checking if player can leave
    public bool CanPlayerLeave()
    {
        return stationCompleted; 
    }

    // Called by StationTrigger when the player actually exits (if allowed)
    public void OnPlayerExitStation()
    {
        Debug.Log("Player exited station area.");
        isPlayerInside = false;
    }

    private IEnumerator RaiseWallAfterDelay()
    {
        // Wait the designated delay (2 seconds)
        yield return new WaitForSeconds(delayBeforeWall);

        if (isPlayerInside)
        {
            // Enable the wall GameObject
            stationWall.SetActive(true);
            Debug.Log("Wall enabled! Temporarily ignoring collision to prevent push-out...");

            // 1) Get the wall's collider
            Collider wallCollider = stationWall.GetComponent<Collider>();
            if (wallCollider == null)
            {
                Debug.LogError("StationWall has no Collider component!");
                yield break;
            }

            // 2) Ignore collisions between player and wall for ~0.2s
            Physics.IgnoreCollision(playerCollider, wallCollider, true);
            yield return new WaitForSeconds(0.2f);
            Physics.IgnoreCollision(playerCollider, wallCollider, false);

            Debug.Log("Collision re-enabled; player is now locked inside without being pushed out.");

            // Here you could start another coroutine to complete the station after 5s, etc.
            // For example:
            // StartCoroutine(WaitBeforeStationComplete(5f));
        }
    }

    // Example optional station completion mechanic:
    /*
    private IEnumerator WaitBeforeStationComplete(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        stationCompleted = true;
        Debug.Log("Station completed! Disabling the wall so player can leave.");
        stationWall.SetActive(false);
    }
    */
}
