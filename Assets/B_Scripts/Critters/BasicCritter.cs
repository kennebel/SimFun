using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCritter : MonoBehaviour
{
    #region Unity Editor Fields
    public float Speed = 25;
    #endregion

    #region Properties
    public Transform Trans { get; set; }

    public Vector3 Target { get; set; }

    public State CurrentState { get; set; }

    private GameObject Sphere { get; set; }
    #endregion

    #region Local Enums
    public enum State { Targeting, Moving, Spinning };
    #endregion

    #region Unity Events
    void Awake()
    {
        Trans = transform;

        PickNewTarget();
        CurrentState = State.Targeting;
    }

    void Update()
    {
        switch (CurrentState)
        {
            case State.Targeting: Targeting(); break;
            case State.Moving: Moving(); break;
        }
    }
    #endregion

    #region Methods
    public void PickNewTarget(float distance = 15f)
    {
        var newPoint = Random.onUnitSphere;
        Target = new Vector3(newPoint.x * distance, 0, newPoint.z * distance) + Trans.position;

        if (Sphere == null) { Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); }
        Sphere.transform.position = Target;
    }

    public void Targeting()
    {
        var q = Quaternion.LookRotation(Target - Trans.position);

        var Angle = Quaternion.Angle(Trans.rotation, q);
        if (Angle > 0.5f)
        {
            Trans.rotation = Quaternion.RotateTowards(Trans.rotation, q, Speed * Time.deltaTime);
        }
        else
        {
            Trans.rotation = q;
            CurrentState = State.Moving;
        }
    }

    public void Moving()
    {
        var Distance = (Trans.position - Target).magnitude;

        if (Distance > 0.1f)
        {
            Trans.Translate(Trans.forward * ((Speed / 3f) * Time.deltaTime), Space.World);
        }
        else
        {
            Trans.position = Target;

            PickNewTarget();
            CurrentState = State.Targeting;
        }
    }
    #endregion
}
