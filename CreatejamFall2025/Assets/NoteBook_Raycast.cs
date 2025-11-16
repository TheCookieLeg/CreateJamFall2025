using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class NoteBook_Raycast : MonoBehaviour {

    //References UIs
    [Header("Camera")]
    [SerializeField] private Camera _camera;


    [Header("Input key")]
    [SerializeField] private KeyCode interactKey;

    //Reference to components
    private Camera cam;

    //Reference to gameobjects
    private GameObject NoteBook;



    void Start()
    {
        cam = GetComponent<Camera>();
        NoteBook = GameObject.FindWithTag("NoteBook");
    }

    void Update()
    {

       

        //Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //casts ray from center of screen


        /*
        //Raycast to detect readable items
        if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.gameObject;
            if (readableItem == NoteBook)
            {

                Crosshair.color = Color.green;

                /*
                if (Input.GetKeyDown(interactKey)) //If interact key is pressed(S)
                {
                    NoteBook.GetComponent<NoteBook_page>().OpenNoteBook(); //TODO: open notebook page
                }
            }
            else if (readableItem == null)
            { 
                Crosshair.color = Color.white; //default crosshair color
            }
        } */

    }
    //open notebook function
    
}
