using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _movementSpeed = "MovementSpeed",
        jump = "Jump";


    public void SetSpeed(float speed)
    {
        Debug.Log("Speed: " + speed);
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

}
