using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
// using System.IO;
// using UniyuEngine.Networking;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelay; //s
    public double marginOfError; //s
    public int inputDelay; //ms

    public string fileLocation;
    public float noteTime; //time note will be on screen (Spawn to Tap)
    public float noteSpawnY;
    public float noteTapY;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile; //where midi will load on ram after parsed


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ReadFromFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetMidiData();
    }

    public void GetMidiData()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelay);
    }

    public void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }
}
