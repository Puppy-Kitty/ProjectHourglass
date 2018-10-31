using UnityEngine;

public class TranslateModule : MonoBehaviour
{
    // Min, Max, and Current Translation variables
    public Vector2 m_minTranslateModifier = Vector2.one;
    public Vector2 m_maxTranslateModifier = Vector2.one;

    public Vector2 m_currentModifier = Vector2.zero;

    // Translation on object start
    private Vector3 m_baseTranslate = Vector3.zero;

    // Sets starting location
    void Start()
    {
        m_baseTranslate = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goal;

        m_currentModifier = Vector2.Min(m_currentModifier, m_maxTranslateModifier);
        m_currentModifier = Vector2.Max(m_currentModifier, m_minTranslateModifier);

        goal.x = m_baseTranslate.x + m_currentModifier.x;
        goal.y = m_baseTranslate.y + m_currentModifier.y;
        goal.z = 0;

        transform.localPosition = goal;
    }

    public bool CanAdjustTranslate()
    {
        return m_minTranslateModifier != m_maxTranslateModifier;
    }
}