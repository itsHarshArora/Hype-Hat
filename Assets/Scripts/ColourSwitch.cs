using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwitch : MonoBehaviour
{
    public Material material1;
    public Material material2;

    public GameObject hatTop;
    public GameObject hatBase;

    public ParticleSystem TrailEffect;
    public static bool firstMaterial;
    public static bool secondndMaterial;

    public GameObject ClickSfx;

    void Start()
    {
        hatTop.GetComponent<MeshRenderer>().material = material1;
        hatBase.GetComponent<MeshRenderer>().material = material1;
        firstMaterial = true;
        secondndMaterial = false;

        ParticleSystem.MainModule main = TrailEffect.GetComponent<ParticleSystem>().main;
        main.startColor = new Color(1f, 0.4f, 0.4f, 1f);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(ClickSfx, gameObject.transform.position, Quaternion.identity);
            if (firstMaterial == true && PlayerController.isGrounded == false)
            {
                secondndMaterial = true;
                firstMaterial = false;
                hatTop.GetComponent<MeshRenderer>().material = material2;
                hatBase.GetComponent<MeshRenderer>().material = material2;
                ParticleSystem.MainModule main = TrailEffect.GetComponent<ParticleSystem>().main;
                main.startColor = new Color(0.4f, 0.5f, 1f, 1f);
            }
            else if (secondndMaterial == true && PlayerController.isGrounded == false)
            {
                firstMaterial = true;
                secondndMaterial = false;
                hatTop.GetComponent<MeshRenderer>().material = material1;
                hatBase.GetComponent<MeshRenderer>().material = material1;
                ParticleSystem.MainModule main = TrailEffect.GetComponent<ParticleSystem>().main;
                main.startColor = new Color(1f, 0.4f, 0.4f, 1f);
            }
        }
    }
}
