using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public void onButtonHover(Image _image)
    {
        _image.enabled = true;
    }

    public void onButtonOut(Image _image)
    {
        _image.enabled = false;
    }
}
