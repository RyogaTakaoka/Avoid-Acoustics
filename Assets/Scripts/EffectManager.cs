using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private string musicData;
    private MusicScore musicScore;
    private Queue<Notes> notes;
    public Transform[] genPositions;
    private Notes tempNote;
    int count = 0;

    public void EffectStart(int stageNum)
    {
        musicData = File.ReadAllText("Assets/Resources/Stage" + stageNum + "_1" + ".json");
        musicScore = JsonUtility.FromJson<MusicScore>(musicData);
        notes = new Queue<Notes>(musicScore.notes);
        tempNote = notes.Dequeue();
        StartCoroutine("GenObject");

        InvokeRepeating("GenObject", 0f, 60f / musicScore.BPM / tempNote.LPB);
    }

    public void GenObject()
    {
        if (notes.Count == 0)
            return;

        if (count == tempNote.num)
        {
            Spawn();
        }

        count++;

    }

    public void Spawn()
    {
        int laneNum = tempNote.block;

        EffekseerHandle handle = EffekseerSystem.PlayEffect("Particle01", genPositions[laneNum].position);

        if (notes.Count > 0)
        {
            tempNote = notes.Dequeue();

            if (count == tempNote.num)
            {
                Spawn();
            }
        }
    }

}