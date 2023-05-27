using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour , IPointing
{
    [SerializeField] private int m_pointValue = 1;

    public void GetPoint()
    {
    }

    public int GetPointValue()
    {
        return m_pointValue;
    }
}
