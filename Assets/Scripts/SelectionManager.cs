using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class SelectionManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenTab(string url);
    public static void OpenURL(string url)
    {
    #if !UNITY_EDITOR && UNITY_WEBGL
        OpenTab(url);
    #endif
    }

    public Material Github_selected;
    public Material Github_default;
    public Material Linkedin_selected;
    public Material Linkedin_default;
    public Material cw_default;
    public Material cw_selected;
    public string selectableTag="Selectable";

    public GameObject MainCameraPlayer;
    public GameObject BtechPanel;
    public GameObject schoolPanel;
    public GameObject menuManagerObj;
    Transform current_selection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (current_selection != null) {
            var selectionRenderer = current_selection.GetComponent<Renderer>();
            if (current_selection.gameObject.name == "Linkedin_icon")
                selectionRenderer.material = Linkedin_default;
            if (current_selection.gameObject.name == "Github_icon")
                selectionRenderer.material = Github_default;
            if (current_selection.gameObject.name == "Coursework_Btn_Btech" || current_selection.gameObject.name == "Coursework_Btn_12th")
                selectionRenderer.material = cw_default;
            if (current_selection.gameObject.name == "IPW_Btn" || current_selection.gameObject.name == "LC_SC_Btn"
                || current_selection.gameObject.name == "LC_PS_Btn" || current_selection.gameObject.name == "PMS_Btn"
                )
                selectionRenderer.material = cw_default;
            if (current_selection.gameObject.name == "ICPU_Btn" || current_selection.gameObject.name=="NNDL_Btn" || current_selection.gameObject.name == "IDNL_Btn")
                selectionRenderer.material = cw_default;
            current_selection = null;

        }
        var ray = Camera.main.ScreenPointToRay(new Vector3 (Screen.width / 2,Screen.height / 2,0 ));
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObj;
        if (Physics.Raycast(ray, out hitObj)) {
            var selection = hitObj.transform;
            if (selection.CompareTag(selectableTag)) 
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && selection.gameObject.name=="Linkedin_icon")
                {
                    selectionRenderer.material = Linkedin_selected;
                }
                if (selectionRenderer != null && selection.gameObject.name == "Github_icon")
                {
                    selectionRenderer.material = Github_selected;
                }
                if (selectionRenderer != null && (selection.gameObject.name == "Coursework_Btn_Btech"|| selection.gameObject.name == "Coursework_Btn_12th"))
                {
                    selectionRenderer.material = cw_selected;
                }
                if (selectionRenderer != null && (selection.gameObject.name == "IPW_Btn" || selection.gameObject.name == "LC_SC_Btn"
                        || selection.gameObject.name == "LC_PS_Btn" || selection.gameObject.name == "PMS_Btn"
                    ))
                {
                    selectionRenderer.material = cw_selected;
                }
                if (selectionRenderer != null && (selection.gameObject.name == "ICPU_Btn" || selection.gameObject.name == "NNDL_Btn" || selection.gameObject.name == "IDNL_Btn"))
                {
                    selectionRenderer.material = cw_selected;
                }


                current_selection = selection;
            }
            
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            if (Cursor.visible == true) 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            if (hitObj.transform != null)
            {
                if (hitObj.collider.name == "Linkedin_icon")
                    OpenURL("https://www.linkedin.com/in/vishal-karthikeyan-ab4a60184/");
                if (hitObj.collider.name == "Github_icon")
                    OpenURL("https://github.com/vishalkarthik17");

                if (hitObj.collider.name == "IPW_Btn")
                    OpenURL("https://github.com/vishalkarthik17/Interactive-Personal-Website-3D");
                if (hitObj.collider.name == "LC_SC_Btn")
                    OpenURL("https://github.com/vishalkarthik17/LoseControl2D-UnityGame");
                if (hitObj.collider.name == "LC_PS_Btn")
                    OpenURL("https://play.google.com/store/apps/details?id=com.VishalKarthik.LoseControl2d");
                if (hitObj.collider.name == "PMS_Btn")
                    OpenURL("https://github.com/vishalkarthik17/ProjectManagementSystem_Faculty_App");

                if (hitObj.collider.name == "ICPU_Btn")
                    OpenURL("https://www.coursera.org/account/accomplishments/certificate/NKVRLFNX5GTC");
                if (hitObj.collider.name == "NNDL_Btn")
                    OpenURL("https://www.coursera.org/account/accomplishments/certificate/X9RBAEKTPRTY");
                if (hitObj.collider.name == "IDNL_Btn")
                    OpenURL("https://www.coursera.org/account/accomplishments/certificate/XH89WTGZCXBX");

                if (hitObj.collider.name== "Coursework_Btn_Btech")
                {
                    BtechPanel.SetActive(true);
                    MainCameraPlayer.GetComponent<LookMouse>().unlockCursor();
                    menuManagerObj.GetComponent<MenuManagerScript>().canMouseInput = false;
                }
                if (hitObj.collider.name == "Coursework_Btn_12th")
                {
                    schoolPanel.SetActive(true);
                    MainCameraPlayer.GetComponent<LookMouse>().unlockCursor();
                    menuManagerObj.GetComponent<MenuManagerScript>().canMouseInput = false;
                }
            }
            
        }
    }
}
