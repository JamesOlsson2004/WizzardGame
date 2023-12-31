using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public void UpLeft()
    {
        Stats.GetComponent<PlayerMovement>().maxSpeed += 1;
    }
    public void UpMiddle()
    {
        Stats.GetComponent<PlayerMovement>().AccelerationSpeed += 1;
    }
    public void UpRight()
    {
        Stats.GetComponent<PlayerMovement>().Jumpheight += 1;
    }
    public void BottomRight()
    {
        Ball.GetComponent<ExplosiveTestBall>().radius += 1;
    }
    public void BottomMiddle()
    {
        Ball.GetComponent<ExplosiveTestBall>().power += 1;
    }
    public void BottomLeft()
    {
        Ball.GetComponent<ExplosiveTestBall>().Power += 1;
    }

    public GameObject Ball;
    public GameObject Stats;

    public GameObject TextUpLeft;
    public GameObject TextUpMiddle;
    public GameObject TextUpRight;
    public GameObject TextBottomRight;
    public GameObject TextBottomMiddle;
    public GameObject TextBottomLeft;

    void Update()
    {
        TextUpLeft.GetComponent<TextMeshProUGUI>().text = "Max Speed: " + Stats.GetComponent<PlayerMovement>().maxSpeed;
        TextUpMiddle.GetComponent<TextMeshProUGUI>().text = "Acceleration Speed: " + Stats.GetComponent<PlayerMovement>().AccelerationSpeed;
        TextBottomRight.GetComponent<TextMeshProUGUI>().text = "Jump Height: " + Stats.GetComponent<PlayerMovement>().Jumpheight;
        TextBottomRight.GetComponent<TextMeshProUGUI>().text = "Explosion Radius: " + Ball.GetComponent<ExplosiveTestBall>().radius;
        TextBottomMiddle.GetComponent<TextMeshProUGUI>().text = "Projectile Power: " + Ball.GetComponent<ExplosiveTestBall>().power;
        TextBottomLeft.GetComponent<TextMeshProUGUI>().text = "Projectile Speed: " + Ball.GetComponent<ExplosiveTestBall>().Power;
    }
}
