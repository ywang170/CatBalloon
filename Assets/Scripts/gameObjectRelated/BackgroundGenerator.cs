using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

    public Transform backgroundPrefab;
    public GameObject canvas;

    private GameObject currentTopBackground;
    private float screenHeight;

	// Use this for initialization
	void Start () {
        var screenWidthFloat = (float)Screen.width;
        var screenHeightFloat = (float)Screen.height;
        screenHeight = screenHeightFloat / screenWidthFloat * 750f;
        generateNewTopBackground();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTopBackground.GetComponent<RectTransform>().offsetMin.y < 0)
        {
            generateNewTopBackground();
        }
	}

    private void generateNewTopBackground()
    {
        var newBackground = Instantiate(backgroundPrefab);
        newBackground.transform.SetParent(canvas.transform, false);
        currentTopBackground = newBackground.gameObject;
        var currentTopBackgroundRect = currentTopBackground.GetComponent<RectTransform>();
        currentTopBackgroundRect.offsetMin = new Vector2(currentTopBackgroundRect.offsetMin.x, screenHeight);
        currentTopBackgroundRect.offsetMax = new Vector2(currentTopBackgroundRect.offsetMax.x, screenHeight);
    }
}
