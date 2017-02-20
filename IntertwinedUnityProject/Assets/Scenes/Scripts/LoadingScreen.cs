using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    public bool KeepMusic = true;
    public GUISkin gameSkin;
    public Texture2D paintBiNumbersLogo, loadBar, loadBarBack;

    private float verticalRes = 1080.0f, horizontalRes, timer, timerScale;

	// Use this for initialization
	void Start () {
        if (KeepMusic) KeepMusicThroughScene();
        timer = 0;
        UserScore.Instance.Load();
        horizontalRes = verticalRes / Screen.height * Screen.width;

       //bool didLoad =  PlayerLevelSystem.Instance.Load();

      // if (!didLoad)
       //{
        //   PlayerLevelSystem.Instance.InitList();
      // }
       //    PlayerLevelSystem.Instance.printToScreen();
	}
	
	// Update is called once per frame
	void Update () {
        //Load Stuff Hear
        timer += Time.deltaTime;
        timerScale = timer / 5.0f;

        if (timer > 5.0f)
        {
            Application.LoadLevel("MainMenu");
            this.enabled = false;
        }
	}

    private static void KeepMusicThroughScene()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        GameObject.DontDestroyOnLoad(music);
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

        GUI.DrawTexture(new Rect(horizontalRes / 2 - paintBiNumbersLogo.width / 2, verticalRes / 2 - paintBiNumbersLogo.height / 2, paintBiNumbersLogo.width, paintBiNumbersLogo.height), paintBiNumbersLogo);

        GUI.DrawTexture(new Rect(horizontalRes / 2 - paintBiNumbersLogo.width / 2 + 25, verticalRes - 250, paintBiNumbersLogo.width - 50, 10), loadBarBack);
        GUI.DrawTexture(new Rect(horizontalRes / 2 - paintBiNumbersLogo.width / 2 + 25, verticalRes - 250, (paintBiNumbersLogo.width - 50) * timerScale, 10), loadBar);
    }
}
