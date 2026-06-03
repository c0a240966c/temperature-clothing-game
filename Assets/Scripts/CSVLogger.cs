using System.IO;
using UnityEngine;

public class CSVLogger : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Application.dataPath + "/result.csv";
        File.WriteAllText(path, "Clothing,Time,Mistakes\n");
    }

    public void Save(string clothing, float time, int mistakes)
    {
        string line = $"{clothing},{time},{mistakes}\n";
        File.AppendAllText(path, line);
    }
}
