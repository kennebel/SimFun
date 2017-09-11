using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousCube : MonoBehaviour
{
    #region Unity Editor Fields
    public float Bottom = 3f;
    public float Top = 5f;
    public float Speed = 1f;
    #endregion

    #region Local Properties
    private Transform Trans { get; set; }
    private bool MovingUp { get; set; }
    #endregion

    #region Unity Events
    void Awake()
    {
        Trans = transform;

        if (Trans.localPosition.y <= Bottom) { MovingUp = true; }
    }

    void Update()
    {
        if (Trans.localPosition.y <= Bottom) { MovingUp = true; }
        else if (Trans.localPosition.y >= Top) { MovingUp = false; }

        Trans.Translate(0, Speed * Time.deltaTime * (MovingUp ? 1 : -1), 0);
    }
    #endregion
}
