using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Startpanel;
    public bool canMouseInput;
    public GameObject BtechCoursePanel;
    public GameObject schoolCoursePanel;
    public GameObject MainCameraPlayer;
    void Start()
    {
        canMouseInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMouseInput == false)
        {
            canMouseInput = true;
            Startpanel.gameObject.SetActive(false);

        }
    }

    public void closeBtechCoursePanel()
    {
        BtechCoursePanel.SetActive(false);
        MainCameraPlayer.GetComponent<LookMouse>().lockCursor();
        canMouseInput = true;
    }
    public void closeSchoolCoursePanel()
    {
        schoolCoursePanel.SetActive(false);
        MainCameraPlayer.GetComponent<LookMouse>().lockCursor();
        canMouseInput = true;
    }
}
