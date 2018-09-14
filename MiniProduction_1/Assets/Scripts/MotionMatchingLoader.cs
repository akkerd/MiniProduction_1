using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Matching
{
    public int[][] to_idx_mapper;
    public FrameMapper[] to_frame_mapper;
    public int[][] neighbors;
    public float[][] neighbors_dist;
    public int[] animation_total_frames;
}

public class FrameMapper
{
    public string AniName;
    public int AniIndex;
    public int Frame;
}

public class MotionMatchingLoader : Manager<MotionMatchingLoader> {

    public Matching StasisMatching;
    public Matching ConfusedMatching;
    public Matching ScaredMatching;
    public Matching StrongMatching;
    public Matching ToStrong;
    public Matching ToConfused;
    public Matching ToScared;
    // Use this for initialization
    protected override void onAwake () {
        StasisMatching = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\stasis_matching.json"));
        ConfusedMatching = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\confused_matching.json"));
        ScaredMatching = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\scared_matching.json"));
        StrongMatching = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\strong_matching.json"));
        ToStrong = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\to_strong_matching.json"));
        ToConfused = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\to_confused_matching.json"));
        ToScared = JsonConvert.DeserializeObject<Matching>(File.ReadAllText(@"Assets\Animations\Data\to_scared_matching.json"));
    }

    public Matching FromState(State state)
    {
        switch(state)
        {
            case State.Stasis:
                return StasisMatching;
            case State.Confused:
                return ConfusedMatching;
            case State.Scared:
                return ScaredMatching;
            case State.Strong:
                return StrongMatching;
        }
        return null;
    }
}
