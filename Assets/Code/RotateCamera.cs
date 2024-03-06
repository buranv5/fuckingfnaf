using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private int VectorRotate = 2;
    private void FixedUpdate()
    {
        if (transform.localPosition.x >= 145)
        {
            VectorRotate = -2;
        }
        else if (transform.localPosition.x <= -145)
        {
            VectorRotate = 2;
        }

        transform.localPosition += new Vector3(VectorRotate, 0, 0);
    }
}
