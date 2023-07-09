using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    void Start () {
	    QualitySettings.vSyncCount = 2;  // VSync must be disabled
	    Application.targetFrameRate = 30;
    }
}
