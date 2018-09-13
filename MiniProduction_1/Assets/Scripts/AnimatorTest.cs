using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class Matching
{
    public int[][] to_idx_mapper;
    public FrameMapper[] to_frame_mapper;
    public int[][] neighbors;
    public float[][] neighbors_dist;
    public int[] animation_total_frames;
}

class FrameMapper
{
    public string AniName;
    public int AniIndex;
    public int frame;
}

enum State
{
    Standup, Stasis, Confused, Scared, Strong, None
};

public class AnimatorTest : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animationState;
    private State CurrentState = State.None;
    private int CurrentAnimationI;
    private readonly Dictionary<State, int[]> Animations = new Dictionary<State, int[]>();
    private readonly Dictionary<State, Matching> Matchings = new Dictionary<State, Matching>();

    Matching StrongMatching;
	void Start () {
        int[] StasisAnimations = new int[12];
        int[] ConfusedAnimations = new int[12];
        int[] ScaredAnimations = new int[12];
        int[] StrongAnimations = new int[12];

        CurrentState = State.Standup;

        Matching StasisMatching = JsonUtility.FromJson<Matching>(File.ReadAllText(@"Assets\Animations\Data\stasis_matching.json"));
        Matchings.Add(State.Stasis, StasisMatching);
        Matching ConfusedMatching = JsonUtility.FromJson<Matching>(File.ReadAllText(@"Assets\Animations\Data\confused_matching.json"));
        Matchings.Add(State.Confused, ConfusedMatching);
        Matching ScaredMatching = JsonUtility.FromJson<Matching>(File.ReadAllText(@"Assets\Animations\Data\scared_matching.json"));
        Matchings.Add(State.Scared, ScaredMatching);
        Matching StrongMatching = JsonUtility.FromJson<Matching>(File.ReadAllText(@"Assets\Animations\Data\strong_matching.json"));
        Matchings.Add(State.Strong, StrongMatching);

        anim = GetComponent<Animator>();
        for (int i = 0; i < StasisAnimations.Length; i++)
            StasisAnimations[i] = (Animator.StringToHash("stash" + i));
        Animations.Add(State.Stasis, StasisAnimations);

        for (int i = 0; i < ConfusedAnimations.Length; i++)
            ConfusedAnimations[i] = (Animator.StringToHash("confused" + i));
        Animations.Add(State.Confused, ConfusedAnimations);

        for (int i = 0; i < ScaredAnimations.Length; i++)
            ScaredAnimations[i] = (Animator.StringToHash("scared" + i));
        Animations.Add(State.Scared, ScaredAnimations);

        for (int i = 0; i < StrongAnimations.Length; i++)
            StrongAnimations[i] = (Animator.StringToHash("strong" + i));
        Animations.Add(State.Strong, StrongAnimations);

        anim.Play("standup");
    }
	
	// Update is called once per frame
	void Update () {
        animationState = anim.GetCurrentAnimatorStateInfo(0);
        Matching matching = null;
        if (Input.anyKeyDown && CurrentState.Equals(State.Stasis))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CurrentState = State.Confused;
                matching = Matchings[State.Confused];
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CurrentState = State.Scared;
                matching = Matchings[State.Scared];
            } else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CurrentState = State.Strong;
                matching = Matchings[State.Strong];
            }

            if (matching != null)
            {
                int[] anims = Animations[CurrentState];
                anim.Play(anims[Random.Range(0, anims.Length)], -1, 0.1f);
            }
        } else if (animationState.normalizedTime > 0.99)
        {
            if (CurrentState.Equals(State.Standup))
            {
                int[] StasisAnimations = Animations[State.Stasis];
                CurrentAnimationI = Random.Range(0, StasisAnimations.Length);
                anim.Play(StasisAnimations[CurrentAnimationI]);
            } else // We are looping an animation
            {
                matching = Matchings[CurrentState];
                Transition(matching);
            }
        }
	}

    private void Transition(Matching nextMatching)
    {
        Matching currentMatching = Matchings[CurrentState];
        int frame = (int)animationState.normalizedTime * currentMatching.animation_total_frames[CurrentAnimationI];
        int idx = nextMatching.to_idx_mapper[CurrentAnimationI][frame];
        int[] neighbors = nextMatching.neighbors[idx];
        int nextIdx = neighbors[0];
        FrameMapper nextFrame = nextMatching.to_frame_mapper[nextIdx];
        CurrentAnimationI = nextFrame.AniIndex;
        CurrentState = StrToState(nextFrame.AniName);
        float normalizedTime = nextFrame.frame / nextMatching.animation_total_frames[CurrentAnimationI];
        anim.Play(Animations[CurrentState][CurrentAnimationI], -1, normalizedTime);
    }

    private float NormalizeFrame(int frame, int totalFrames)
    {
        return frame == 0 ? 0f : frame / totalFrames-1;
    }

    private int UnNormalizeFrame(float normalizedFrame, int totalFrames)
    {
        return (int)normalizedFrame * totalFrames;
    }

    private KeyCode RetKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
                return key;
        }
        return KeyCode.None;
    }

    private State StrToState(string state)
    {
        switch (state)
        {
            case "standup":
                return State.Standup;
            case "stasis":
                return State.Stasis;
            case "confused":
                return State.Confused;
            case "scared":
                return State.Scared;
            case "strong":
                return State.Strong;
            default:
                return State.None;
        }
    }
}
