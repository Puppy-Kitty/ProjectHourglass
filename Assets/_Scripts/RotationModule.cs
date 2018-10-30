using UnityEngine;

public class RotationModule : MonoBehaviour
{
    public bool m_canRotateFreely = false;
    public float m_minRotationZ = 0.0f;
    public float m_maxRotationZ = 0.0f;
    
    // Use this for initialization
    void Start ()
    {
        if (m_minRotationZ > m_maxRotationZ)
        {
            throw new System.ArgumentOutOfRangeException(name, "Min rotation is higher than max rotation.");
        }
        if (m_maxRotationZ - m_minRotationZ > 360)
        {
            throw new System.ArgumentOutOfRangeException(name, "Rotation range wider than 360 degrees, please simplify.");
        }
        else if (m_maxRotationZ - m_minRotationZ == 360)
        {
            throw new System.ArgumentOutOfRangeException(name, "Use Can Rotate Freely instead.");
        }
        if (m_minRotationZ <= -360 || m_maxRotationZ > 360)
        {
            throw new System.ArgumentOutOfRangeException(name, "Rotation clamp(s) beyond +-360.  Please simplify.");
        }
        if (m_maxRotationZ < 0)
        {
            throw new System.ArgumentOutOfRangeException(name, "Max rotation less than zero.  Please simplify.");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!m_canRotateFreely)
        {
            float relativeRange = (m_maxRotationZ - m_minRotationZ) / 2f;
            float offset = m_maxRotationZ - relativeRange;
            Vector3 angles = transform.eulerAngles;
            float z = ((angles.z + 540) % 360) - 180 - offset;

            if(Mathf.Abs(z) > relativeRange)
            {
                angles.z = relativeRange * Mathf.Sign(z) + offset;
                transform.eulerAngles = angles;
            }
        }
    }

    public bool CanAdjustRotation()
    {
        return m_minRotationZ != m_maxRotationZ || m_canRotateFreely;
    }
}
