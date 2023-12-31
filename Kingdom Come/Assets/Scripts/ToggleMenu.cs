using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    [Header("Menu Game Objects")]
    public Camera MenuCamera;
    public GameObject SpellTree;
    public GameObject Menu;
    public bool InMenu = false;
    public Camera MainCamera;

    KeyCode lastKey;

    void Update()
    {
        if (InMenu && (Input.GetKeyDown(lastKey) || (Input.GetKeyDown(KeyCode.Escape))))
        {
            CloseMenus();
            MainCamera.enabled = true;
            MenuCamera.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            InMenu = false;
            return;
        }

        if (Input.GetKeyDown("u"))
        {
            CloseMenus();
            Menu.SetActive(true);
            lastKey = KeyCode.U;
            InMenu = true;
        }
        if (Input.GetKeyDown("i"))
        {
            CloseMenus();
            SpellTree.SetActive(true);
            lastKey = KeyCode.I;
            InMenu = true;
        }
        if (Input.GetKeyDown("o"))
        {
            CloseMenus();
            lastKey = KeyCode.O;
            InMenu = true;
        }
        if (Input.GetKeyDown("p"))
        {
            CloseMenus();
            lastKey = KeyCode.P;
            InMenu = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenus();
            lastKey = KeyCode.Escape;
            InMenu = true;
        }

        if (InMenu)
        {
            MenuCamera.enabled = true;
            MainCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void CloseMenus()
    {
        GameObject[] Menus;
        Menus = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject x in Menus)
        {
            if (x.activeSelf == true)
            { x.SetActive(false); }
        }
    }
}
