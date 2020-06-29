using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer player;

    void Start()
    {
        GameObject.FindObjectOfType<ChromakeyController>().planeGenerator.HidePlanesChromakey();
    }

    void Update()
    {
        if (player.isPaused)
        {            
            StartCoroutine(WaitToDestroy());
        }

        transform.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up, Vector3.Cross(Vector3.up, Camera.main.transform.forward)), Vector3.up);
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);
        GameObject.FindObjectOfType<ChromakeyController>().ShowPlanes();
        Destroy(gameObject);
    }
}
