using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Select Target for camera follow")]
    [SerializeField] private Transform target;
    [SerializeField] private float followHeight;
    [SerializeField] private float followDistance;
    [SerializeField] private float smoothness;
    [SerializeField] private float lerpClamp;
    private float desiredHeight;
    private float desiredDistance;
    [SerializeField] private float lookAtRotation;

    private void FixedUpdate()
    {
        if (target == null)
            return; //if target not assign it will return and not gonna work.

        transform.rotation = Quaternion.Euler(lookAtRotation, target.rotation.y, transform.rotation.z);
        desiredHeight = target.position.y + followHeight;
        desiredDistance = target.position.z - followDistance;
        if (Vector3.Distance(transform.position, new Vector3(target.position.x, desiredHeight, desiredDistance)) >= lerpClamp)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, desiredHeight, desiredDistance), smoothness * Time.fixedDeltaTime);
        }

    }

}
