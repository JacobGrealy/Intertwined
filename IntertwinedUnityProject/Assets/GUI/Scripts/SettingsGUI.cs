using UnityEngine;
using System.Collections;

public class SettingsGUI : MonoBehaviour {

    public GUISkin gameSkin;
    public MainMenuGUI mainMenu;

    public AudioClip[] clips;

    private int currentClip;
    private AudioSource music;
    private float verticalRes = 1080.0f, horizontalRes;
    private Vector2 buttonSize = new Vector2(600, 150);

    // Use this for initialization
    void Start()
    {
        this.enabled = false;
        horizontalRes = verticalRes / Screen.height * Screen.width;
        currentClip = 0;
        music = GameObject.Find("Music").GetComponent<AudioSource>();
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

        GUI.Label(new Rect(horizontalRes / 2 - 225, verticalRes / 2 - 250, 450, 50), "Music Volume");
        music.volume = GUI.HorizontalSlider(new Rect(horizontalRes / 2 - 225, verticalRes / 2 - 200, 450, 50), music.volume, 0.0f, 1.0f);

        GUI.Label(new Rect(horizontalRes / 2 - 225, verticalRes / 2 - 150, 450, 50), "Master Volume");
        AudioListener.volume = GUI.HorizontalSlider(new Rect(horizontalRes / 2 - 225, verticalRes / 2 - 100, 450, 50), AudioListener.volume, 0.0f, 1.0f);

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 - 50, buttonSize.x, buttonSize.y), "How to Play"))
        {
        }

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 + 100, buttonSize.x, buttonSize.y), "Toggle Music"))
        {
            currentClip++;
            if (currentClip == clips.Length)
            {
                currentClip = 0;
            }
            music.clip = clips[currentClip];
            music.Play();
        }

        if (GUI.Button(new Rect(horizontalRes / 2 - buttonSize.x / 2, verticalRes / 2 + 250, buttonSize.x, buttonSize.y), "Back"))
        {
            mainMenu.enabled = true;
            this.enabled = false;
        }
    }
}
