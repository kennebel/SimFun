using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region Unity Editor Fields
    public float MinutesPerFullCycle = 10;
    #endregion

    #region Local Fields
    private float _TimeOfDay = 6f;
    #endregion

    #region Properties
    public static SceneManager Instance { get; private set; }

    public float Temperature { get; set; }

    public float TimeOfDay
    {
        get { return _TimeOfDay; }
        set
        {
            if (value > 24) { value -= 24f; }
            else if (value < 0) { value = 0f; }
            _TimeOfDay = value;
        }
    }
    #endregion

    #region Unity Events
    void Awake()
    {
        Instance = this;

        Temperature = 21f;
    }

    void Update()
    {
        TimeOfDay += Time.deltaTime * (MinutesPerFullCycle / 60f);
    }
    #endregion

    #region Methods
    public void SetTimeOfDay(float timeIn24)
    {
        TimeOfDay = timeIn24;
    }
    #endregion
}
