using UnityEngine;
using System.Collections;

public class EndGUI : MonoBehaviour {

    public GUISkin gameSkin;
    public Texture2D gameOver, medal;

	private float verticalRes = 1080.0f, horizontalRes;
    private Vector2 buttonSize = new Vector2(500, 150);

	// Use this for initialization
	void Start () {

        horizontalRes = verticalRes / Screen.height * Screen.width;
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (UserScore.Instance.bestScore < UserScore.Instance.score)
        {
            UserScore.Instance.bestScore = UserScore.Instance.score;
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

        GUI.DrawTexture(new Rect(horizontalRes / 2 - gameOver.width / 2, verticalRes / 2 - gameOver.height, gameOver.width, gameOver.height), gameOver);

        GUI.Box(new Rect(horizontalRes / 2 - 450, verticalRes / 2 - 150, 900, 400), " ");

        GUI.Label(new Rect(horizontalRes / 2 - 375, verticalRes / 2 - 85, 300, 50), "Score");
        GUI.Label(new Rect(horizontalRes / 2 - 375, verticalRes / 2 - 35, 300, 50), UserScore.Instance.score.ToString());

        GUI.Label(new Rect(horizontalRes / 2 - 375, verticalRes / 2 + 75, 300, 50), "Best");
        GUI.Label(new Rect(horizontalRes / 2 - 375, verticalRes / 2 + 125, 300, 50), UserScore.Instance.bestScore.ToString());

        GUI.DrawTexture(new Rect(horizontalRes / 2 + 50, verticalRes / 2 - 75, 250, 250), medal);

        //GUI.Label(new Rect(horizontalRes / 2 - 325, verticalRes / 2 - 25, 300, 50), "Score");
        //GUI.Label(new Rect(horizontalRes / 2 - 325, verticalRes / 2 + 25, 300, 50), UserScore.Instance.score.ToString());

        //GUI.Label(new Rect(horizontalRes / 2 , verticalRes / 2 - 25, 300, 50), "Best");
        //GUI.Label(new Rect(horizontalRes / 2 , verticalRes / 2 + 25, 300, 50), UserScore.Instance.bestScore.ToString());

        if(GUI.Button(new Rect(horizontalRes / 2, verticalRes / 2 + 2 * buttonSize.y, buttonSize.x, buttonSize.y), "Play Again")){

            UserScore.Instance.Save();
            Application.LoadLevel("Game");
        }

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x, verticalRes / 2 + 2 * buttonSize.y, buttonSize.x, buttonSize.y), "Main Menu"))
        {
            UserScore.Instance.Save();
            Application.LoadLevel("MainMenu");
        }
    }
}
