using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[XmlRoot("HighScoreData")]
public class UserScore {
    [XmlIgnore]
    private static UserScore instance = new UserScore();

    [XmlIgnore]
    public static UserScore Instance
    {
        get
        {
            return instance;
        }
    }

    [XmlIgnore]
    internal float score;



    [XmlAttribute("HighScore")]
    public float bestScore;

    [XmlAttribute("Proton")]
    public int ProtonCount;

    [XmlAttribute("Neutron")]
    public int NeutronCount;

    public void Save()
    {
        Debug.Log("Saving");
        XmlSerializer serializer = new XmlSerializer(typeof(UserScore));
        using (Stream stream = File.Create(Application.persistentDataPath + @"/highScore.xml"))
        {
            serializer.Serialize(stream, this);
        }
    }

    public void Load()
    {

        Debug.Log("Loading");
        try
        {
            using (var file = File.Open(Application.persistentDataPath + @"/highScore.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(UserScore));
                instance = (UserScore)xml.Deserialize(file);
            }
        }
        catch (Exception)
        {
        }

        //XmlSerializer serializer = new XmlSerializer(typeof(UserScore));
        //if (File.Exists(Application.persistentDataPath + @"/highScore.xml"))
        //{
        //    using (FileStream stream = new FileStream(Application.persistentDataPath + @"/highScore.xml", FileMode.Open))
        //    {
        //        instance = serializer.Deserialize(stream) as UserScore;
        //    }
        //}
    }
}
