using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject panel;
    GameObject player;
    PlayerMove PlayerMove;
    Rigidbody2D PlayerRgd;
    // Start is called before the first frame update

    public void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerMove = player.GetComponent<PlayerMove>();
        PlayerRgd = player.GetComponent<Rigidbody2D>();
    }

    public void LeftDown()
    {
        PlayerMove.inputLeft = true;
    }
    public void LeftUp()
    {
        PlayerMove.inputLeft = false;
    }
    public void RightDown()
    {
        PlayerMove.inputRight = true;
    }
    public void RightUp()
    {
        PlayerMove.inputRight = false;
    }

    public void JumpDown()
    {
        PlayerMove.inputJump = true;
    }
    public void JumpUp()
    {
        PlayerMove.inputJump = false;
    }
    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
    public void Restartbtn()
    {
        PlayerRgd.position = new Vector3(-1.5f, -3.5f, 0);
    }
}
