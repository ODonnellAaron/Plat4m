﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    PlayerMovement Player;
    Rigidbody playerBody;

    public bool collidedWithWall = false;
    public bool collisionEnded = false;

    public void InstatiatePlayer(PlayerMovement player)
    {
        Player = player;
        playerBody = player.GetComponent<Rigidbody>();
    }

    public void OnCollisionWithWall(Collision collision)
    {
        if (collision.transform.tag == "MovingWall")
        {
            collidedWithWall = true;
            //Debug.Log(collidedWithWall);
        }
    }

    public void BasicCollision(Collision collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "MovingPlatform")
        {
            playerBody.freezeRotation = true;
            Player.isGrounded = true;
            Player.isJumping = false;
            Player.ResetJump();
        }

        if (collision.transform.tag == "MovingPlatform")
        {
            playerBody.transform.parent = collision.transform;
        }
    }

    public void OnCollisionEnd(Collision collider)
    {
        if (collider.transform.tag == "MovingPlatform")
        {
            playerBody.transform.parent = null;
            playerBody.freezeRotation = true;
        }

        if (collider.transform.tag == "MovingWall")
        {
            collisionEnded = true;
            //playerBody.freezeRotation = true;
            //playerBody.useGravity = true;
            //collidedWithWall = false;
        }
    }
}