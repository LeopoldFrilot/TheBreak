using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float radiusOfMovement = 5f;
    public float returnRate = 10f;
    public float strafeRate = 5f;

    [Header("For viewing purposes only")]
    [SerializeField] bool canMove = false;
    [SerializeField] Vector3 curFacingVector;
    [SerializeField] Ray centerRay;
    [SerializeField] float perpDistanceToCenter;
    [SerializeField] Vector3 curPerpPosition;

    
    private void Start()
    {
        StartMovement();
    }
    private void Update()
    {
        float xInput = 0;
        float yInput = 0;
        if (canMove)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }

        Move(xInput, yInput);
    }

    public void StartMovement()
    {
        curFacingVector = transform.forward;
        centerRay = new Ray(transform.position, curFacingVector);
        canMove = true;
    }

    void UpdatePerpendicularDistanceToCenterRay()
    {
        float distanceToRayStart = Vector3.Distance(transform.position, centerRay.origin);
        Vector3 pointAlongRay = centerRay.GetPoint(distanceToRayStart);
        float theta = Vector3.Angle(curFacingVector, (transform.position - centerRay.origin));
        perpDistanceToCenter = Mathf.Sin(Mathf.Deg2Rad * theta) * distanceToRayStart;
        curPerpPosition = centerRay.GetPoint(Mathf.Cos(Mathf.Deg2Rad * theta) * distanceToRayStart);
    }

    void Move(float xInput, float yInput)
    {
        UpdatePerpendicularDistanceToCenterRay();
        if(Mathf.Abs(xInput) <= 0f && Mathf.Abs(yInput) <= 0f)
        {
            ReturnToCenter();
        }
        else
        {
            transform.position += transform.right * xInput * Time.deltaTime * strafeRate;
            transform.position += transform.up * yInput * Time.deltaTime * strafeRate;
        }
    }

    void ReturnToCenter()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            Vector3.zero, 
            returnRate * Time.deltaTime);
    }
}
