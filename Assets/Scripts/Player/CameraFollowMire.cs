using UnityEngine;

public class CameraFollowMire : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 7f, -10);
    }
}
