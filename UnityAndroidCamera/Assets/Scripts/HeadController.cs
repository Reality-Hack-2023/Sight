using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;

using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadController : MonoBehaviour
{
    [Tooltip("File of YOLO model. If you want to use another than YOLOv2 tiny, it may be necessary to change some const values in YOLOHandler.cs")]
    public NNModel modelFile;
    [Tooltip("Text file with classes names separated by coma ','")]
    public TextAsset classesFile;
    [Tooltip("Material with image")]
    public Material displayMaterial;
    [Tooltip("Session to detec head move")]
    public ARSessionOrigin sessionOrigin;

    
    [Range(0.05f, 1f)]
    [Tooltip("The minimum value of box confidence below which boxes won't be drawn.")]
    public float MinBoxConfidence = 0.3f;

    [Tooltip("Where to play music")]
    public GameObject wallVideo;

    private Quaternion previousDeviceRotation;
    private int frameCounter;
    private bool isMovementDetected;
    NNHandler nn;
    YOLOHandler yolo;
    string[] classesNames;



    void Start()
    {
        previousDeviceRotation = sessionOrigin.trackablesParent.transform.rotation;
        frameCounter = 0;
        isMovementDetected = false;
        nn = new NNHandler(modelFile);
        yolo = new YOLOHandler(nn);

        classesNames = classesFile.text.Split(',');
    }

    void Update()
    {
        Quaternion currentDeviceRotation = sessionOrigin.trackablesParent.transform.rotation;
        Quaternion deltaRotation = currentDeviceRotation * Quaternion.Inverse(previousDeviceRotation);
        previousDeviceRotation = currentDeviceRotation;

        // Check if the angle of rotation is greater than 1 degree
        float angle = Quaternion.Angle(Quaternion.identity, deltaRotation);
        if (angle > 1.0f)
        {
            frameCounter++;
        }
        else
        {
            frameCounter = 0;
        }

        // Check if the device has been moved for more than 20 frames
        if (frameCounter > 2)
        {
            isMovementDetected = true;
            frameCounter = 0;
        }

        // Do something with the device pose, for example:
        if (isMovementDetected)
        {
            // Do something when movement is detected
            //for example setting a flag to true and use that flag in other scripts to take actions
            var path = "Assets/Sounds/";


            // Create a new Texture2D with the same dimensions as the material texture
            Texture2D image = new Texture2D(displayMaterial.mainTexture.width,
                                            displayMaterial.mainTexture.height);

            // Copy the pixels from the material texture to the new Texture2D
            image.ReadPixels(new Rect(0,
                                      0,
                                      displayMaterial.mainTexture.width,
                                      displayMaterial.mainTexture.height), 0, 0);
            image.Apply();

            var boxes = yolo.Run(image);

            wallVideo.AddComponent<AudioSource>();
            AudioSource audioSourceTest = GetComponent<AudioSource>();
            var pathTest = "Assets/Sounds/audio_stinger.wav";
            audioSourceTest.clip = Resources.Load<AudioClip>(pathTest);
            audioSourceTest.loop = false;
            audioSourceTest.volume = 1.0f;
            audioSourceTest.Play();




            foreach (var box in boxes ) {
                wallVideo.AddComponent<AudioSource>();
                AudioSource audioSource = GetComponent<AudioSource>();

                switch (box.bestClassIdx) {
                    case 0:
                        path += "Alive_Object_loop_C.wav";
                        break;
                    case 1:
                        path += "dead_loop_01.wav";
                        break;
                    case 2:
                        path += "Dead_loop_C_2.wav";
                        break;
                    case 3:
                        path += "MBNC_01.wav";
                        break;
                    case 4:
                        path += "organic_stinger_C.wav";
                        break;
                    case 5:
                        path += "UI_01.wav";
                        break;
                    case 6:
                        path += "UI_02.wav";
                        break;
                    case 7:
                        path += "audio_stinger.wav";
                        break;
                    case 8:
                        path += "Wall_MBNC_02.wav";
                        break;
                    case 9:
                        path += "Alive_Object_loop_C.wav";
                        break;
                    case 10:
                        path += "dead_loop_01.wav";
                        break;
                    case 11:
                        path += "Dead_loop_C_2.wav";
                        break;
                    case 12:
                        path += "MBNC_01.wav";
                        break;
                    case 13:
                        path += "organic_stinger_C.wav";
                        break;
                    case 14:
                        path += "UI_01.wav";
                        break;
                    case 15:
                        path += "UI_02.wav";
                        break;
                    case 16:
                        path += "audio_stinger.wav";
                        break;
                    case 17:
                        path += "Wall_MBNC_02.wav";
                        break;
                    default:
                        path += "audio_stinger.wav";
                        break;

                }
                audioSource.clip = Resources.Load<AudioClip>(path);
                audioSource.loop = false;
                audioSource.volume= box.confidence;
                audioSource.Play();
            }
        }
    }
}
