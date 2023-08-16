using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _rigTransform;
    private Transform _cameraTransform;
    private Tuple<GameObject, GameObject> _followTargets;
    
    private void Awake()
    {
        _rigTransform = GetComponent<Transform>();
        _cameraTransform = GetComponentInChildren<Transform>();
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
        _cameraTransform.position = new Vector3(0, distance * Mathf.Sqrt(2) / 6, 0);
    }
}
