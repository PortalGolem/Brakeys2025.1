using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraConstraintScript : MonoBehaviour
{
    [SerializeField] int delayFrames;
    [SerializeField] Transform cameraTransform;
    private List<Vector3> previousPositions = new List<Vector3>();
    private List<Vector3> previousRotations = new List<Vector3>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int x = 0; x <= delayFrames; x++){
            previousPositions.Add(Vector3.zero);
        }

        for (int x = 0; x <= delayFrames; x++){
            previousRotations.Add(Vector3.zero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= delayFrames; i++){
            if (i == delayFrames){
                previousPositions[i] = transform.position;
            }
            else{
                previousPositions[i] = previousPositions[i+1];
            }
        }
        cameraTransform.position = previousPositions[0];

        for (int i = 0; i <= delayFrames; i++){
            if (i == delayFrames){
                previousRotations[i] = transform.rotation.eulerAngles;
            }
            else{
                previousRotations[i] = previousRotations[i+1];
            }
        }
        cameraTransform.rotation = Quaternion.Euler(previousRotations[0]);
    }
}
