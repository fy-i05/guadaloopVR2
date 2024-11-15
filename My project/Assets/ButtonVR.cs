using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    private Vector3 originalPosition;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        originalPosition = button.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(
                originalPosition.x, 
                originalPosition.y - 0.003f,
                originalPosition.z
            );
            presser = other.gameObject;
            onPress.Invoke();
            isPressed=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject==presser)
        {
            button.transform.localPosition = originalPosition;
            onRelease.Invoke();
            isPressed=false;
        }
    }
    /*public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        sphere.transform.localPosition = new Vector3(1,0,6);
        sphere.AddComponent<Rigidbody>();
    }*/
    public void SpawnText()
    {
        //Debug.Log("SpawnText() method called.");
        GameObject textObject = new GameObject("SpawnedText");
        textObject.transform.localPosition = new Vector3(.796f, 1.0f, 4.18f);

        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = "donuts!";
        textMesh.fontSize = 40;
        textMesh.color = Color.black;

        textObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
