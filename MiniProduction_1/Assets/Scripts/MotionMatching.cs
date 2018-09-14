using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum State
{
    Standup, Stasis, Confused, Scared, Strong, None
};

public class MotionMatching : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animationState;
    private State CurrentState = State.None;
    private int CurrentAnimationI;
    private readonly Dictionary<State, int[]> Animations = new Dictionary<State, int[]>();
    float[] Rotation = new float[3];
    private bool debug = false;

	void Start () {
        int[] StasisAnimations = new int[12];
        int[] ConfusedAnimations = new int[12];
        int[] ScaredAnimations = new int[12];
        int[] StrongAnimations = new int[12];

        CurrentState = State.Standup;

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

        Transform t = GetComponent<Transform>();
        Rotation[0] = t.eulerAngles.x;
        Rotation[1] = t.eulerAngles.y;
        Rotation[2] = t.eulerAngles.z;

        anim.Play("Standup", 0, 0.0246913580246914f);
        anim.speed = 0;
    }

	void Update () {

        animationState = anim.GetCurrentAnimatorStateInfo(0);
        if (debug && Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StandUp();
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Confused();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Scared();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Strong();
            }
        } else if (animationState.normalizedTime > 0.9)
        {
            if (CurrentState.Equals(State.Standup))
            {
                int[] StasisAnimations = Animations[State.Stasis];
                CurrentState = State.Stasis;
                CurrentAnimationI = UnityEngine.Random.Range(0, StasisAnimations.Length);
                anim.Play(StasisAnimations[CurrentAnimationI], 0, 0.1f);
            } else // We are looping an animation
            {
                Transition(MotionMatchingLoader.Instance.FromState(CurrentState));
            }
        }
	}

    public void StandUp()
    {
        anim.applyRootMotion = true;
        transform.parent = null;
        anim.Play("Standup", 0, 0.0246913580246914f);
        anim.speed = 1;
    }

    public void Confused()
    {
        Transition(MotionMatchingLoader.Instance.ToConfused);
    }

    public void Scared()
    {
        Transition(MotionMatchingLoader.Instance.ToScared);
    }

    public void Strong()
    {
        Transition(MotionMatchingLoader.Instance.ToStrong);
    }

    private void Transition(Matching nextMatching)
    {
        Matching currentMatching = MotionMatchingLoader.Instance.FromState(CurrentState);
        int frame = (int)Math.Round(animationState.normalizedTime * currentMatching.animation_total_frames[CurrentAnimationI]);
        int idx = nextMatching.to_idx_mapper[CurrentAnimationI][frame];
        int[] neighbors = nextMatching.neighbors[idx];
        int nextIdx = neighbors[0];
        FrameMapper nextFrame = nextMatching.to_frame_mapper[nextIdx];
        CurrentAnimationI = nextFrame.AniIndex;
        CurrentState = StrToState(nextFrame.AniName);
        float normalizedTime = (float)nextFrame.Frame / nextMatching.animation_total_frames[CurrentAnimationI];

        // So the sleeve looks straight when transitioning
        GetComponent<Transform>().eulerAngles = new Vector3(Rotation[0], Rotation[1], Rotation[2]);

        anim.Play(Animations[CurrentState][CurrentAnimationI], 0, normalizedTime);
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
