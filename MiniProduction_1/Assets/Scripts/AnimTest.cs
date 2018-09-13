using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class AnimTest : MonoBehaviour {

    string walkLeft = @"Assets\Animations\walkCircleLeft_001_dt.bvh";

    Transform hips;
    Transform leftUpLeg;
    Transform leftLeg;
    Transform rightUpLeg;
    Transform rightLeg;
    Transform spine;
    Transform spine2;


    List<float[]> frames = new List<float[]>();
    float frameFloat = 0f;
    int frameIndex = 0;
    // Use this for initialization
    void Start () {
        StreamReader file = new StreamReader(walkLeft);
        string line;
        while ((line = file.ReadLine()) != null)
        {
            if (line.Equals("MOTION"))
                break;
        }
        file.ReadLine();
        file.ReadLine();
        while ((line = file.ReadLine()) != null)
        {
            frames.Add(line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(float.Parse).ToArray());
        }
        file.Close();

        hips = GetComponent<Transform>().Find("RokokoGuy_Hips");

        leftUpLeg = hips.Find("RokokoGuy_LeftUpLeg");
        leftLeg = leftUpLeg.Find("RokokoGuy_LeftLeg");
        rightUpLeg = hips.Find("RokokoGuy_RightUpLeg");
        rightLeg = rightUpLeg.Find("RokokoGuy_RightLeg");
        spine = hips.Find("RokokoGuy_Spine");
        spine2 = spine.Find("RokokoGuy_Spine2");
    }
	
	// Update is called once per frame
	void Update () {
		if (frameIndex >= frames.Count())
        {
            frameIndex = 0;
            frameFloat = 0f;
        }

        float[] frame = frames[frameIndex];

        hips.position = new Vector3(frame[0]/100, frame[1]/100, frame[2]/100);
        hips.eulerAngles = new Vector3(frame[4], frame[3], frame[5]);
        leftUpLeg.eulerAngles = new Vector3(frame[7], frame[6], frame[8]);
        leftLeg.eulerAngles = new Vector3(frame[10], frame[9], frame[11]);
        rightUpLeg.eulerAngles = new Vector3(frame[19], frame[18], frame[20]);
        rightLeg.eulerAngles = new Vector3(frame[22], frame[21], frame[23]);
        spine.eulerAngles = new Vector3(frame[31], frame[30], frame[32]);
        spine2.eulerAngles = new Vector3(frame[34], frame[33], frame[35]);

        frameFloat += 0.01f;
        frameIndex += 1;// (int)frameFloat;
	}
}
