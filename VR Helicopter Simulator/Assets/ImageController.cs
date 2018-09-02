using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	public RectTransform image;
	public RectTransform canavas;

	void Start () {
		adapt_image_size();
	}

	public void adapt_image_size() {
		image.sizeDelta = canavas.sizeDelta;
	}
}
