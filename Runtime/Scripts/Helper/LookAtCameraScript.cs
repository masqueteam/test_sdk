<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasqueSDK.Helper
{
    public class LookAtCameraScript : MonoBehaviour
    {
        void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * -Vector3.back,
                Camera.main.transform.rotation * -Vector3.down);
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasqueSDK.Helper
{
    public class LookAtCameraScript : MonoBehaviour
    {
        void Update()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * -Vector3.back,
                Camera.main.transform.rotation * -Vector3.down);
        }
    }
}
>>>>>>> aca2d79 (-init)
