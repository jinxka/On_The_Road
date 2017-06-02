using UnityEngine;
using System.Collections;

public class Forcefield_anim : MonoBehaviour {
    public GameObject player;
    public Material mat;
    public float scrollspeed = 0.5F;
    private float offset = 0;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = player.transform.position;
        offset = Time.time + scrollspeed % 1;
        mat.mainTextureOffset = new Vector2(offset, offset);
	}
}
