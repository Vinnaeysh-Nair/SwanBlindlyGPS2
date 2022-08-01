using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingJumpButton : MonoBehaviour
{
    [SerializeField] private PlayerJump playerJump;

    public void OnClickJump()
    {
        playerJump.Jumping();
    }


}
