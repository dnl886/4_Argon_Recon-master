using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float speed = 22f;
    //[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In ms")] [SerializeField] float xRange = 12f;
    [Tooltip("In ms")] [SerializeField] float yRange = 12f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20;

    [SerializeField] float positionYawFactor = 5f;
    //[SerializeField] float controlYawFactor = -30;

    //[SerializeField] float positionRollFactor = -5f;
    [SerializeField] float controlRollFactor = -20;

    float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslations();
        ProcessRotations();
        
    }
    void ProcessRotations()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToRotation = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToRotation;

        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;
        

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslations()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame

        Debug.Log(yOffsetThisFrame);

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
