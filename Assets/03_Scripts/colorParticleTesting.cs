using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorParticleTesting : MonoBehaviour
{
    ParticleSystem ps;
    Gradient lifeGradient;
    Gradient speedGradient;
    
    public Vector4 color1 = new Vector4(0f, 0f, 0f);

    
    

    void Update()
    {
        
        var ps = GetComponent<ParticleSystem>();
    
        var colorOverLifeModule = ps.colorOverLifetime;
        colorOverLifeModule.enabled = true;

        var colorBySpeedModule = ps.colorBySpeed;
        colorBySpeedModule.enabled = false;

        
        colorOverLifeModule.color = lifeGradient;
        colorBySpeedModule.color = speedGradient;


        lifeGradient = new Gradient();
        lifeGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color1, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(1f, .1f), new GradientAlphaKey(1f, .9f), new GradientAlphaKey(0f, 1f) }
           
        );

         
        colorOverLifeModule.color = new ParticleSystem.MinMaxGradient(lifeGradient);

        
       
    }

   
    /*void Update()
    {
        var colorOverLifeModule = ps.colorOverLifetime;
        var colorBySpeedModule = ps.colorBySpeed;

        lifeGradient = new Gradient();
        speedGradient = new Gradient();
        
        colorOverLifeModule.color = lifeGradient;
        colorBySpeedModule.color = speedGradient;

        
        lifeGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color1, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(1f, .1f), new GradientAlphaKey(1f, .9f), new GradientAlphaKey(0f, 1f) }
           
        );

        speedGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0f, 0f), new GradientAlphaKey(1f, .1f), new GradientAlphaKey(1f, .9f), new GradientAlphaKey(0f, 1f) }
        );
        

        
        colorOverLifeModule.color = new ParticleSystem.MinMaxGradient(lifeGradient);

        
        colorBySpeedModule.color = new ParticleSystem.MinMaxGradient(speedGradient);
        

    }*/
}
