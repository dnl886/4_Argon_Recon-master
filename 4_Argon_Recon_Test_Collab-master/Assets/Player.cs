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
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    void ProcessTranslations()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime; //how many centermiters do i need to move in this frame

        //print(xOffsetThisFrame);

        float rawXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawYPos = transform.localPosition.y + yOffsetThisFrame;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
