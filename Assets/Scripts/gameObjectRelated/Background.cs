using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Background : MonoBehaviour {

    public float speed = 2f;
    public int decorationMaxNum = 2;

    private float screenHeight;
    private List<GameObject> backgroundDecorations;

	// Use this for initialization
	void Start () {
        var screenWidthFloat = (float)Screen.width;
        var screenHeightFloat = (float)Screen.height;
        screenHeight = screenHeightFloat / screenWidthFloat * 750f;

        var rnd = new System.Random();
        var decorationNum = rnd.Next(0, decorationMaxNum + 1);
        var backgroundDecorationsArray = 
            Resources.LoadAll<GameObject>("Prefabs/backgroundDecorations");
        backgroundDecorations = backgroundDecorationsArray.ToList();
        generateDecorations(decorationNum);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, speed * (0 - Time.deltaTime), 0);
        if (this.gameObject.GetComponent<RectTransform>().offsetMin.y < 0 - screenHeight)
        {
            Object.Destroy(this.gameObject);
        }
	}

    void generateDecorations(int decorationNum)
    {

        for (int i = 0; i < decorationNum; i++)
        {
            var decorationPrefab = backgroundDecorations [Random.Range (0, backgroundDecorations.Count)];
            var decoration = Instantiate (decorationPrefab) as GameObject;
            // Randomly move object in range of horizontal (-750 / 2 + width / 2) to (750 / 2 - width / 2), and
            // vertical (-screenHeight / 2 + height / 2) to (screenHeight / 2 - height / 2)
            var decorationRect = (RectTransform)decoration.transform;
            var horizontalCoord =
                Random
                .Range(
                    (-750 / 2) + (decorationRect.rect.width / 2),
                    (750 / 2) - (decorationRect.rect.width / 2));
            var verticalCoord =
                Random
                .Range(
                    (-screenHeight / 2) + (decorationRect.rect.height / 2),
                    (screenHeight / 2) - (decorationRect.rect.height / 2));
            decoration.transform.Translate(horizontalCoord, verticalCoord, 0);
            decoration.transform.SetParent(this.transform, false);
        }
    }
}
