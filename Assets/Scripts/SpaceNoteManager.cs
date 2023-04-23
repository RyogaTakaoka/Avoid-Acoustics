using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpaceNoteManager : NoteManager
{
    float nowTime;
    float repeatTime;
    public int orderScore = 0;
    bool isStart = false;


    public override void NoteStart(int stageNum)
    {
        ReadScore();
        isStart = true;
    }

    public override void GenObject()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            if (count == tempNote[i].num)
            {
                Spawn(i);
            }

        }

        count++;

        if (count > tempNote[0].num && count > tempNote[1].num && orderScore <= 11)
        {
            ReadScore();
        }

    }

    public void ReadScore()
    {
        Debug.Log(orderScore);
        musicData0 = File.ReadAllText("Assets/Resources/Stage3" + "_" + orderScore + ".json");
        musicScore0 = JsonUtility.FromJson<MusicScore>(musicData0);
        notes[0] = new Queue<Notes>(musicScore0.notes);
        tempNote[0] = notes[0].Dequeue();
        orderScore++;

        musicData1 = File.ReadAllText("Assets/Resources/Stage3" + "_" + orderScore + ".json");
        musicScore1 = JsonUtility.FromJson<MusicScore>(musicData1);
        notes[1] = new Queue<Notes>(musicScore1.notes);
        tempNote[1] = notes[1].Dequeue();
        orderScore++;

        //InvokeRepeating("GenObject", 0f, 60f / musicScore0.BPM / tempNote[0].LPB);
        nowTime = 0;
        repeatTime = 60f / musicScore0.BPM / tempNote[0].LPB;
        count = 0;
    }

    private void Update()
    {
        if (isStart)
        {
            nowTime += Time.deltaTime;
            if (nowTime >= repeatTime)
            {
                GenObject();

                nowTime -= repeatTime;
            }
        }
    }
}