using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraFit : MonoBehaviour
    {
        public Camera cam;
        public float defaultSize = 9.6f;

        // Start is called before the first frame update
        void Awake()
        {
            //#if UNITY_ANDROID || UNITY_IOS
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = 10.8f / 19.2f;

            if (screenRatio >= targetRatio)
            {
                cam.orthographicSize = defaultSize;
            }
            else
            {
                float changeSize = targetRatio / screenRatio;
                cam.orthographicSize = defaultSize * changeSize;
            }
            //#endif
        }
    }
