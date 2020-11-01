using UnityEngine;
using WebXR;

public class DesertFreeFlightController : MonoBehaviour {

    [SerializeField]
    public Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;

    [Tooltip("Enable/disable rotation control. For use in Unity editor only.")]
    public bool rotationEnabled = true;

    [Tooltip("Enable/disable translation control. For use in Unity editor only.")]
    public bool translationEnabled = true;

    private WebXRDisplayCapabilities capabilities;

    [Tooltip("Mouse sensitivity")]
    public float mouseSensitivity = 1f;

    [Tooltip("Straffe Speed")]
    public float straffeSpeed = 5f;

    private float minimumX = -360f;
    private float maximumX = 360f;

    private float minimumY = -90f;
    private float maximumY = 90f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    Quaternion originalRotation;

    void Start()
    {
        WebXRManager.Instance.OnXRChange += onXRChange;
        WebXRManager.Instance.OnXRCapabilitiesUpdate += onXRCapabilitiesUpdate;
        originalRotation = transform.localRotation;
    }

    private void onXRChange(WebXRState state)
    {
        if (state == WebXRState.ENABLED)
        {
            DisableEverything();
        }
        else
        {
            EnableAccordingToPlatform();
        }
    }

    private void onXRCapabilitiesUpdate(WebXRDisplayCapabilities vrCapabilities)
    {
        capabilities = vrCapabilities;
        EnableAccordingToPlatform();
    }

    void Update() {
        if (translationEnabled)
        {
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * straffeSpeed;
            float z = Input.GetAxis("Vertical") * Time.deltaTime * straffeSpeed;

            transform.Translate(x, 0, z);
        }

        if (rotationEnabled && Input.GetMouseButton(0))
        {
            // Get smooth mouse look.
            Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
            appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
            currentMouseLook += appliedMouseDelta;
            currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

            // Rotate camera and controller.
            transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
        }
    }

    void DisableEverything()
    {
        translationEnabled = false;
        rotationEnabled = false;
    }

    /// Enables rotation and translation control for desktop environments.
    /// For mobile environments, it enables rotation or translation according to
    /// the device capabilities.
    void EnableAccordingToPlatform()
    {
        rotationEnabled = translationEnabled = !capabilities.supportsImmersiveVR;
    }

    public static float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp (angle, min, max);
    }
}
