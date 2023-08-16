using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _rigTransform;
    [SerializeField] private Transform _cameraTransform;
    private Tuple<GameObject, GameObject> _followTargets;
    
    private void Awake()
    {
        // _rigTransform.position = Vector3.zero;
        // _cameraTransform.position = new Vector3(-30, 30, 0);
        // _cameraTransform.LookAt(_rigTransform);
    }

    private void Update()
    {
        if (_followTargets != null)
        {
            //---------------------------------------------//
            // TODO: Make the camera movement smooth, LERP //
            //---------------------------------------------//
            SetRigLocation();
            SetCameraHeight();
            _cameraTransform.LookAt(_rigTransform.position);
        }
    }

    public void SetTargets(Tuple<GameObject, GameObject> players)
    {
        _followTargets = players;
    }
    
    private void SetRigLocation()
    {
        _rigTransform.position = (_followTargets.Item1.transform.position + _followTargets.Item2.transform.position) / 2;
    }
    
    private void SetCameraHeight()
    {
        float distance = (_followTargets.Item1.transform.position - _followTargets.Item2.transform.position).magnitude;
        _cameraTransform.position = new Vector3(_rigTransform.position.x, distance * Mathf.Sqrt(2), _rigTransform.position.z);
    }
}
