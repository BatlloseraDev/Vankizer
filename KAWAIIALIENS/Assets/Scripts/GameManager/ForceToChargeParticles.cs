using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceToChargeParticles : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particle;

    private ParticleSystem generatedParticle;

    protected void Start()
    {
        generatedParticle = null;
        EmitFX(particle);
    }
    

    public void EmitFX(ParticleSystem particle)
    {
        if(generatedParticle== null)
        {
            generatedParticle = Instantiate(particle, Vector3.zero, Quaternion.identity); 
        }
        generatedParticle.Play(); 


    }


    private void Awake()
    {
       
    }




}
