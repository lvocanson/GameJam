using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ObjectSaver
{
    public static void Save(string fileName, object obj)
    {
        string destination = Application.persistentDataPath + "/" + fileName;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, obj);
        file.Close();
    }

    public static T Load<T>(string fileName)
    {
        string destination = Application.persistentDataPath + "/" + fileName;
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else return default;

        BinaryFormatter bf = new BinaryFormatter();
        T data = (T)bf.Deserialize(file);
        file.Close();
        return data;
    }
}
