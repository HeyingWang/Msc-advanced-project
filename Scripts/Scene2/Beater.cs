using RhythmTool;
using RhythmTool.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beater : MonoBehaviour
{
    //插件
    public RhythmAnalyzer analyzer;
    public RhythmPlayer player;
    public RhythmEventProvider eventProvider;


    public GameObject[] beats;
    private List<Chroma> chromaFeatures;

    private Note lastNote = Note.FSHARP;

    void Awake()
    {

        analyzer.Initialized += OnInitialized;
        //注册事件
        eventProvider.Register<Beat>(OnBeat);
        eventProvider.Register<Onset>(OnOnset);

        chromaFeatures = new List<Chroma>();
    }

    void Update()
    {
        if (!player.isPlaying)
            return;

    }



    private void OnInitialized(RhythmData rhythmData)
    {
        //Start playing the song.
        player.Play();
    }

  //到了节奏点调用，通知所有东西，缩放一下
    private void OnBeat(Beat beat)
    {
        if (player.volume < 0.5f)
            return;
       foreach (var v in beats)
        {
            v.GetComponent<IBeatable>().Beat();
        }
    }

    private void OnOnset(Onset onset)
    {
        //Clear any previous Chroma features.
        chromaFeatures.Clear();

        //Find Chroma features that intersect the Onset's timestamp.
        player.rhythmData.GetIntersectingFeatures(chromaFeatures, onset.timestamp, onset.timestamp);

        //Instantiate a line to represent the Onset and Chroma feature.
     

        if (chromaFeatures.Count > 0)
            lastNote = chromaFeatures[chromaFeatures.Count - 1].note;

    }




}
