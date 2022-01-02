using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Common;

public class PlayerContoller : MonoBehaviour
{

    public Rigidbody pRB;
    private float swerveX;
    private float swerveY;
    [SerializeField] private float moveSpeed;
    private Vector2 startPos;

    private bool oldu;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        var fingers = LeanTouch.Fingers;
        if (fingers.Count > 0)
        {
            if (fingers[0].Down)
            {
                startPos = fingers[0].StartScreenPosition;
            }

            if (fingers[0].Set)
            {
                swerveX = -(startPos.x - fingers[0].LastScreenPosition.x);
                swerveY = -(startPos.y - fingers[0].LastScreenPosition.y);
                Vector3 direction = new Vector3(swerveX, 0f, swerveY).normalized;
                if (direction != Vector3.zero)
                {
                    //pRB.velocity = Vector3.Lerp(pRB.velocity,(direction * moveSpeed),10f);
                    pRB.AddForce((direction*moveSpeed));
                }

                if (swerveX<-0.2f || swerveX>0.2f || swerveY<-0.2f || swerveY>0.2f)
                {
                    startPos = fingers[0].LastScreenPosition;
                }
                
                print(pRB.velocity);
            }

            if (fingers[0].Up)
            {
                swerveX = 0f;
                swerveY = 0f;
            }
        }
    }
}
