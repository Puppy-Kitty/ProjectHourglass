using UnityEngine;

public class ScaleModule : MonoBehaviour
{
    public Vector2 m_minScaleModifier = Vector2.one;
    public Vector2 m_maxScaleModifier = Vector2.one;
    public Vector2 m_currentScaleModifier = Vector2.one;

    private Vector3 m_baseScale = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        m_baseScale = transform.localScale;
    }
    
    // Update is called once per frame
    void Update ()
    {
        m_currentScaleModifier = Vector2.Min(m_currentScaleModifier, m_maxScaleModifier);
        m_currentScaleModifier = Vector2.Max(m_currentScaleModifier, m_minScaleModifier);

        float xScale = m_baseScale.x * m_currentScaleModifier.x;
        float yScale = m_baseScale.y * m_currentScaleModifier.y;
        transform.localScale = new Vector3(xScale, yScale, m_baseScale.z);
    }

    public bool SetScaleModifier(float xScale, float yScale)
    {
        if(xScale >= m_minScaleModifier.x && yScale >= m_minScaleModifier.y &&
            xScale <= m_maxScaleModifier.x && yScale <= m_maxScaleModifier.y)
        {
            m_currentScaleModifier.Set(xScale, yScale);
            return true;
        }
        return false;
    }

    public bool CanAdjustScale()
    {
        return m_minScaleModifier != m_maxScaleModifier;
    }
}
