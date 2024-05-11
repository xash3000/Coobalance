using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private HingeJoint2D joint;
    [SerializeField] private float angleLimit = 40.0f;
    [SerializeField] private Rigidbody2D rb2d;

    void FixedUpdate()
    {

        float currentAngle = joint.jointAngle;

        if (Mathf.Abs(currentAngle) > angleLimit)
        {
            GameManager.Instance.GameOver();
            joint.enabled = false;
            rb2d.gravityScale = 1f;
        }
    }
}
