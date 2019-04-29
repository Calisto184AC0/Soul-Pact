using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : PlayerMovement
{
    public GameObject myCamera;

    float transition = 0.5f;

    public Vector3 targetPosition, actualPositionPlayer, actualPositionCamera;

    GameObject touchedDoor;

    private void Start()
    {
        targetPosition = myCamera.transform.position;
    }

    private void LateUpdate()
    {
        myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, targetPosition, transition);
    }

    void moveCamera(string orientation)
    {
        float cameraX = Mathf.Round(myCamera.transform.position.x / 10) * 10;
        float cameraY = Mathf.Round(myCamera.transform.position.y * 100) / 100;

        switch (orientation)
        {
            case "right":
                targetPosition = new Vector3(cameraX + 20f, cameraY, myCamera.transform.position.z);
                break;
            case "left":
                targetPosition = new Vector3(cameraX - 20f, cameraY, myCamera.transform.position.z);
                break;
            case "up":
                targetPosition = new Vector3(cameraX, cameraY + 11.25f, myCamera.transform.position.z);
                break;
            case "down":
                targetPosition = new Vector3(cameraX, cameraY - 11.25f, myCamera.transform.position.z);
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            touchedDoor = collision.gameObject;

            actualPositionCamera = myCamera.transform.position;

            switch(touchedDoor.GetComponent<NodeLink>().orientation)
            {
                case "right":
                    actualPositionPlayer = transform.position + new Vector3(-3f, 0, 0);
                    moveCamera("right");
                    transform.Translate(new Vector3(2.47f, 0, 0));
                    break;
                case "left":
                    actualPositionPlayer = transform.position + new Vector3(3f, 0, 0);
                    moveCamera("left");
                    transform.Translate(new Vector3(-2.47f, 0, 0));
                    break;
                case "up":
                    actualPositionPlayer = transform.position + new Vector3(0, -3f, 0);
                    moveCamera("up");
                    transform.Translate(new Vector3(0, 2.47f, 0));
                    break;
                case "down":
                    actualPositionPlayer = transform.position + new Vector3(0, 3f, 0);
                    moveCamera("down");
                    transform.Translate(new Vector3(0, -2.47f, 0));
                    break;
            }
        }

        else if (collision.gameObject.CompareTag("Enemy")&& !IsDying)
        {
            Debug.Log("Auch!!");
            KillPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchedDoor = null;
    }

    void KillPlayer()
    {
        
        IsDying = true;
        animator.SetBool("IsMoving", false);
        Debug.Log(controller.playerSoulCount);
        controller.CheckDeath();
        Debug.Log(controller.playerSoulCount);
        Invoke("Respawn", 1f);
    }

    void Respawn()
    {
        transform.position = actualPositionPlayer;
        targetPosition = actualPositionCamera;
        IsDying = false;
    }
}
