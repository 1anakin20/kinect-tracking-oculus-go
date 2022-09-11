using Network;
using UnityEngine;

public class KinectHead : MonoBehaviour
{
    [SerializeField] private OVRCameraRig _cameraRig;
    private KinectTransmissionProtocolReceiver _KSTP;
    [SerializeField] private GameObject _leftController;
    [SerializeField] private GameObject _rightController;


    // Start is called before the first frame update
    void Start()
    {
        _KSTP = new KinectTransmissionProtocolReceiver(4444);
    }

    // Update is called once per frame
    void Update()
    {
        var player = _KSTP.LastPlayer;
        if (player != null)
        {
            var heightOffset = 1.6f;
            transform.localPosition = player.Head + Vector3.up * heightOffset;
            _leftController.transform.localPosition = player.LeftHand;
            _rightController.transform.localPosition = player.RightHand;
        }
    }
}
