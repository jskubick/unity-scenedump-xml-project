using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	public Button theButton;
	public AudioSource sound;
	public Material redMaterial;
	public Material blueMaterial;
	public Material currentMaterial;
	public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
		theButton.onClick.AddListener(buttonClicked);
		cube.GetComponent<Renderer>().material = redMaterial;
		currentMaterial = redMaterial;
    }

	void OnDestroy() {
		theButton.onClick.RemoveListener(buttonClicked);
	}

	void buttonClicked() {
		sound.Play();
		currentMaterial = (currentMaterial == redMaterial) ? blueMaterial : redMaterial;
		cube.GetComponent<Renderer>().material = currentMaterial;

	}


}
