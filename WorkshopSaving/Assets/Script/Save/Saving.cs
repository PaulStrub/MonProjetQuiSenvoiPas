using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
    public static void SaveFunction()
    {
        BinaryFormatter fornatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.bi";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveSystem data = new SaveSystem();

        fornatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveSystem LoadSave()
    {
        string path = Application.persistentDataPath + "/Save.bi";
        if (File.Exists(path))
        {
            BinaryFormatter fornatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveSystem data = fornatter.Deserialize(stream) as SaveSystem;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }


}
