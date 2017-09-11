using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    //#region Unity Editor Fields
    //public float MinutesPerFullCycle = 10;
    //#endregion

    #region Properties
    private Transform Trans { get; set; }
    //private Vector3 RotateSpeed { get; set; }
    #endregion

    #region Unity Events
    void Awake()
    {
        Trans = transform;

        //RotateSpeed = Vector3.forward * (360f / (MinutesPerFullCycle * 60f)); // Rotating around the Z-Axis, nominal east-west motion, presuming +Z is north
    }

    void Update()
    {
        //Trans.Rotate(RotateSpeed * Time.deltaTime);
        var TimeOfDay = SceneManager.Instance.TimeOfDay - 6;
        if (TimeOfDay < 0) { TimeOfDay += 24; }
        Trans.rotation = Quaternion.Euler(0, 0, (TimeOfDay / 24f) * 360f);
    }
    #endregion
}
