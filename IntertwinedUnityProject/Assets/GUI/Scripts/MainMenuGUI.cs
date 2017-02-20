using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

    public GUISkin gameSkin;
    public SettingsGUI settings;
    public Texture2D logo, logoGlow;

    private float verticalRes = 1080.0f, horizontalRes, textureAlpha;
    private Vector2 buttonSize = new Vector2(600, 150);
    private bool increase;

	// Use this for initialization
	void Start () {

        textureAlpha = 0.25f;
        horizontalRes = verticalRes / Screen.height * Screen.width;
	}
	
	// Update is called once per frame
	void Update () {

        if (increase)
        {
            textureAlpha = Mathf.MoveTowards(textureAlpha, 0.75f, 0.0025f);
            if (textureAlpha >= 0.75f)
            {
                increase = false;
            }
        }
        else
        {
            textureAlpha = Mathf.MoveTowards(textureAlpha, 0.25f, 0.0025f);
            if (textureAlpha <= 0.25f)
            {
                increase = true;
            }
        }
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

        GUI.color = new Color(1, 1, 1, textureAlpha);
        GUI.DrawTexture(new Rect(horizontalRes / 2 - logoGlow.width / 2.4f, verticalRes / 2 - logoGlow.height + 75, logoGlow.height, logoGlow.width), logoGlow);

        GUI.color = new Color(1, 1, 1, 1);
        GUI.DrawTexture(new Rect(horizontalRes / 2 - logo.width / 2.4f, verticalRes / 2 - logo.height + 75, logo.height, logo.width), logo);

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 + 50, buttonSize.x, buttonSize.y), "Start Game"))
        {
            Application.LoadLevel("Game");
        }

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 + 200, buttonSize.x, buttonSize.y), "Settings"))
        {
            settings.enabled = true;
            this.enabled = false;
        }

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 + 350, buttonSize.x, buttonSize.y), "Quit"))
        {
            Application.Quit();
        }
    }
}
