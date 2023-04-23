using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    protected string musicData0;
    protected string musicData1;
    protected MusicScore musicScore0;
    protected MusicScore musicScore1;
    public Queue<Notes>[] notes = new Queue<Notes>[2];
    protected Notes[] tempNote = new Notes[2];

    public ObjectPrefab[] objectPrefabs;

    public Transform[] genPositions;

    protected int count = 0;

    SpaceNoteManager spaceScript;

    public virtual void NoteStart(int stageNum)
    {
        musicData0 = File.ReadAllText("Assets/Resources/Stage" + stageNum + "_0" + ".json");
        musicScore0 = JsonUtility.FromJson<MusicScore>(musicData0);
        notes[0] = new Queue<Notes>(musicScore0.notes);
        tempNote[0] = notes[0].Dequeue();

        musicData1 = File.ReadAllText("Assets/Resources/Stage" + stageNum + "_1" + ".json");
        musicScore1 = JsonUtility.FromJson<MusicScore>(musicData1);
        notes[1] = new Queue<Notes>(musicScore1.notes);
        tempNote[1] = notes[1].Dequeue();

        //MusicScore temp = musicScore0;
        //for (int i = 0; i < temp.notes.Length; i++)
        //{
        //    temp.notes[i].num = temp.notes[i].num / temp.notes[i].LPB * 4;
        //    temp.notes[i].LPB = 4;
        //}

        //string jsonData = JsonUtility.ToJson(temp);
        //File.WriteAllText("Assets/Resources/Stage" + stageNum + "_0_fixed" + ".json", jsonData);

        InvokeRepeating("GenObject", 0f, 60f / musicScore0.BPM / tempNote[0].LPB);
    }

    public virtual void GenObject()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            if (notes[i].Count > 0 && count == tempNote[i].num)
            {
                Spawn(i);
            }

        }
        count++;
    }


    /// <summary>
    /// ノーツを生成する関数
    /// </summary>
    /// <param name="index">上下の段の番号</param>
    public void Spawn(int index)
    {
        int laneNum = tempNote[index].block;

        Instantiate(objectPrefabs[index].objectPrefab[laneNum], new Vector3(genPositions[laneNum].position.x, index * -1, genPositions[laneNum].position.z), transform.rotation);

        if (notes[index].Count > 0)
        {
            tempNote[index] = notes[index].Dequeue();
            //if(notes[index].Count == 0)
            //{
            //    Debug.Log(tempNote[0].num);
            //}

            if (count == tempNote[index].num)
            {
                Spawn(index);
            }
        }

        return;
    }

}

/// <summary>
/// 譜面データ
/// </summary>
[System.Serializable]
public class MusicScore
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public int beat;
    public Notes[] notes;
}

[System.Serializable]
public class Notes
{
    public int LPB;
    public int num;
    public int block;
    public int type;
    public Notes[] notes;
}

[System.Serializable]
public class ObjectPrefab
{
    public GameObject[] objectPrefab;
}
