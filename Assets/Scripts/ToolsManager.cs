using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ToolsManager : MonoBehaviour
{
    Rigidbody polishRigidbody;
    Vector3 direction;
    [SerializeField] private float movementSpeed;
    [SerializeField] List<ColorLerpManager> allObjects = new List<ColorLerpManager>();
    [SerializeField] private bool isMoving = false ;
    int colorIndex = 0;
    [SerializeField] int paintBrushColorIndex = 0;
    [SerializeField] ParticleSystem colorParticle;
    [SerializeField] ColorLerpManager paintBrush;
    [SerializeField] ProgressManager progressManager;

    void Start()
    {
        polishRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = Input.GetMouseButton (0);
        if (isMoving)
        {
            direction = new Vector3(0f,Input.GetAxis("Mouse Y"),0f) * movementSpeed * Time.deltaTime;
            //direction.y =  Mathf.Clamp(direction.y, 0.4f, 2.4f);
            polishRigidbody.position += direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "polish")
        {
            if (paintBrushColorIndex <= 9)
            {
                paintBrushColorIndex++;
                if (paintBrushColorIndex == 10)
                {
                    progressManager.PlayParticle();
                    int tempLevel = PlayerPrefs.GetInt("level");
                    tempLevel++;
                    PlayerPrefs.SetInt("level",tempLevel);
                    int y = SceneManager.GetActiveScene().buildIndex;
                }
                progressManager.UpdatePolishSlider((float)paintBrushColorIndex/10);
            }
            if (!colorParticle.isPlaying)
            {
                colorParticle.Play();
            }

            if (colorIndex < 9)
            {
                colorIndex++;
            }
            for (int i = 0; i < allObjects.Count; i++)
            {
                allObjects[i].SetColor(colorIndex);
            }
        }
    }
}
