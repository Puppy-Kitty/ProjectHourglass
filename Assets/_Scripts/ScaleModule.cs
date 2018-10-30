using UnityEngine;

public class ScaleModule : MonoBehaviour
{
    public Vector3 m_minScale = Vector3.one;
    public Vector3 m_maxScale = Vector3.one;

    // Use this for initialization
    void Start ()
    {
        if(m_minScale.x > m_maxScale.x || m_minScale.y > m_maxScale.y)
        {
            throw new System.ArgumentOutOfRangeException(name, "Min scale is higher than max scale.");
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
        Vector3 scale = Vector3.Min(transform.localScale, m_maxScale);
        scale = Vector3.Max(scale, m_minScale);
        transform.localScale = scale;
    }

    public bool SetScale(float xScale, float yScale)
    {
        if(xScale >= m_minScale.x && yScale >= m_minScale.y &&
            xScale <= m_maxScale.x && yScale <= m_maxScale.y)
        {
            transform.localScale = new Vector3(xScale, yScale, transform.localScale.z);
            return true;
        }
        return false;
    }

    public bool CanAdjustScale()
    {
        return m_minScale != m_maxScale;
    }
}
