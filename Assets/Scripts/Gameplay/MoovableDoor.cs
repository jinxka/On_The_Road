using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovableDoor : MonoBehaviour {
    public int distanceToOpenDoor;
    Animator anim;
    GameObject player;
    private InputManager inputManagerDatabase;
    bool doorOpen;
    public GameObject shortcutCanvas;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");
        doorOpen = false;
        anim = GetComponentInParent<Animator>();
        shortcutCanvas.transform.rotation = Quaternion.Euler(60, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

        if (distance <= distanceToOpenDoor && Input.GetKeyDown(inputManagerDatabase.StorageKeyCode))
        {
            MoveDoor();
        }
    }

    void MoveDoor()
    {
        doorOpen = !doorOpen;
        anim.SetBool("Open", doorOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shortcutCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            shortcutCanvas.SetActive(false);
        }
    }

}
