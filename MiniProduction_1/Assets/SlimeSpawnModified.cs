using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnModified : MonoBehaviour
{

    public float SliderValX = 20;
    public float SliderValY = 20;
  
    Rigidbody RigidBod;
    public bool FallsFromSide;
    SkinnedMeshRenderer SMRendereder;
    public GameObject Zipper;
    public bool FallsFromLeft = false;
    SlimeControl ZipperScript;
    ParticleSystem PSystem;


    void Start()
    {

        SMRendereder = gameObject.GetComponent<SkinnedMeshRenderer>();
        

        if (gameObject.GetComponent<Cloth>() != null)
        {
          
            
        }
        else if (gameObject.GetComponent<Rigidbody>() != null)
        {
            RigidBod = gameObject.GetComponent<Rigidbody>();
            RigidBod.isKinematic = true;
            SMRendereder.enabled = true;
        }
        if (GetComponent<ParticleSystem>()!=null)
        {

            PSystem = GetComponent<ParticleSystem>();
        }


        ZipperScript = Zipper.GetComponent<SlimeControl>();

    }

    // Update is called once per frame
    void Update()
    {


        if (RigidBod == null)
        {


            if (ZipperScript.ZipperValY < transform.position.y && FallsFromSide)
            {
                //turn on Particle
                PSystem.Play();
                enabled = false;

            }
            else if (ZipperScript.ZipperValY < transform.position.y && !FallsFromSide && ZipperScript.ZipperValX < transform.position.x)
            {

                //turn on Particle
                PSystem.Play();
                enabled = false;
            }
        }
        else if (RigidBod != null)
        {

            if (ZipperScript.ZipperValY < transform.position.y && FallsFromSide)
            {
                //RigidBod.isKinematic = false;
                FallsFromLeft = true;
            }
            else if (ZipperScript.ZipperValY < transform.position.y && !FallsFromSide && ZipperScript.ZipperValX < transform.position.x)
            {
                //RigidBod.isKinematic = false;
                FallsFromLeft = true;
            }

            if (ZipperScript.ZipperValY > transform.position.y && ZipperScript.ZipperValX < transform.position.x && FallsFromLeft)
            {

                RigidBod.isKinematic = false;
            }

        }
    }
}
