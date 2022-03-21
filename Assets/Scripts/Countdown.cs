using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private TMP_Text textMesh;
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        textMesh.text = "3";
        anim = GetComponent<Animation>();
        anim.enabled = true;
        anim.Play();
    }

    public void Tick() {
        textMesh = GetComponent<TMP_Text>();
        string result = (Int16.Parse(textMesh.text) - 1).ToString();
        if (result != "0") {
            textMesh.text = result;
            anim.Play();
        } else {
            textMesh.text = "";
            anim.enabled = false;
        }
    }
}
