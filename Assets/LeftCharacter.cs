using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] RightSprites = new GameObject[4];
    [SerializeField] private GameObject FaceCharInRoom;
    [SerializeField] private GameObject FaceCharScreamer;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private AudioSource MainDoor;

    [SerializeField] private GameObject CameraCanvas;
}
