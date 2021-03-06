using UnityEngine;

public class Detection : MonoBehaviour
{
    // GENERAL SETTINGS
    [Header("General Settings")]
    [Tooltip("How close the player has to be in order to be able to open/close the door.")]
    public float Reach = 4.0F;
    [HideInInspector] public bool InReach;

    // DEBUG SETTINGS
    [Header("Debug Settings")]
    [Tooltip("The color of the debugray that will be shown in the scene view window when playing the game.")]
    public Color DebugRayColor;
    [Tooltip("The opacity of the debugray.")]
    [Range(0.0F, 1.0F)]
    public float Opacity = 1.0F;

    void Start()
    {
        gameObject.name = "Player";
        gameObject.tag = "Player";

        DebugRayColor.a = Opacity; // Set the alpha value of the DebugRayColor
    }

    void Update()
    {
        // Set origin of ray to 'center of screen' and direction of ray to 'cameraview'
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));

        RaycastHit hit; // Variable reading information about the collider hit

        // Cast ray from center of the screen towards where the player is looking
        if (Physics.Raycast(ray, out hit, Reach))
        {
            if (hit.collider.tag == "Door")
            {
                InReach = true;

                // Give the object that was hit the name 'Door'
                GameObject Door = hit.transform.gameObject;

                // Get access to the 'Door' script attached to the object that was hit
                Door dooropening = Door.GetComponent<Door>();

				// Open/close the door by running the 'Open' function found in the 'Door' script
				if (dooropening.RotationPending == false) StartCoroutine(hit.collider.GetComponent<Door>().Move());
            }

            else
            {
                InReach = false;
            }
        }

        else
        {
            InReach = false;
        }

        //Draw the ray as a colored line for debugging purposes.
        Debug.DrawRay(ray.origin, ray.direction * Reach, DebugRayColor);
    }
}
