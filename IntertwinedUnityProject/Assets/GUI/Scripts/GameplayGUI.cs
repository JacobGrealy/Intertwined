using UnityEngine;
using System.Collections;

public class GameplayGUI : MonoBehaviour {

    public GUISkin gameSkin;
    public Texture2D distanceTexture;

    private float verticalRes = 1080.0f, horizontalRes;
    private Vector2 buttonSize = new Vector2(500, 150);

    // Use this for initialization
    void Start()
    {

        horizontalRes = verticalRes / Screen.height * Screen.width;
    }

    void OnGUI()
    {
        if (gameSkin)
        {
            GUI.skin = gameSkin;
        }
        else
        {
            Debug.Log("StartMenuGUI: GUI Skin object missing!");
        }

        // Scale the GUI to any resolution based on 1920 x 1080 base resolution
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(Screen.height / verticalRes, Screen.height / verticalRes, 1));

        GUI.DrawTexture(new Rect(horizontalRes / 2 - distanceTexture.width / 4, 0, distanceTexture.width / 3, distanceTexture.height / 3), distanceTexture);
        GUI.Label(new Rect(horizontalRes / 2 + 75, 5, distanceTexture.width / 3, distanceTexture.height / 3), UserScore.Instance.score.ToString("F2"), "GameScore");

    }
}
