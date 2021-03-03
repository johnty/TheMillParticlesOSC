using UnityEngine;
using System.Collections;
using System;

public class ParticuleSystemsControler : MonoBehaviour

{
    public OSC osc;
    ParticleSystem ps;
    
    Gradient lifeGradient;
    Gradient speedGradient;
    
    public Vector4 color1 = new Vector4(0f, 0f, 0f);

    [Range(1f, 10f)]
    public float SliderStartLifeTime = 10f;
   
    [Range(200f, 2500f)]
    public float SliderEmitValue = 200.0f;

    public Vector3 ShapePosition = new Vector3(0f, 0f, 0f);
    public Vector3 ShapeRotation = new Vector3(0f, 0f, 0f);

    [Range(-50f, 50f)]
    public float SliderVeloLinearX = 0.0f;
    [Range(-50f, 50f)]
    public float SliderVeloLinearY;
    [Range(-50f, 50f)]
    public float SliderVeloLinearZ = 0.0f;
    [Range(0f, 10f)]
    public float SliderVeloOrbX = 0.0f;
    [Range(0f, 10f)]
    public float SliderVeloOrbY = 0.0f;
    [Range(0f, 10f)]
    public float SliderVeloOrbZ = 0.0f;
    [Range(-30f, 30f)]
    public float SliderVeloRadial = 0.0f;
    [Range(-30f, 30f)]
    public float SliderVelSpeed;

    [Range(0f, 1f)]
    public float LimitVeloSpeed = 0f;
    [Range(0f, .1f)]
    public float LimitVeloDampen = 0f;
    
    [Range(-100f, 100f)]
    public float SliderNoiseXStrength = 0.0f;
    [Range(-100f, 100f)]
    public float SliderNoiseYStrength = 0.0f;
    [Range(-100f, 100f)]
    public float SliderNoiseZStrength = 0.0f;
    [Range(0f, 0.005f)]
    public float SliderNoiseFrequency = 0.0f;
    [Range(0f, 10f)]
    public float SliderNoiseSpeed = 0.0f;
    [Range(-20f, 20f)]
    public float SliderNoisePosition = 0f;
    [Range(0f, 1f)]
    public float SliderNoiseRotation = 0f;
    [Range(0f, 1f)]
    public float SliderNoiseScale = 0f;
    public bool damping = true;


    [Range(0.1f, 2f)]
    public float SizeLife = 1f;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var shape = ps.shape;

        osc.SetAddressHandler("/EmotionXY", OnReceiveEmoXY);

    }

    private void OnReceiveEmoXY(OscMessage oscM)
    {
        float x = oscM.GetFloat(0);
        float y = oscM.GetFloat(1);
        SliderVelSpeed = x;
        SliderNoiseXStrength = y;
        string msg = "OSC: " + x.ToString() + " : " + y.ToString();
        Debug.Log(oscM);
    }

    void Update()
    {
        var main = ps.main;
        main.startLifetime = SliderStartLifeTime;

        var em = ps.emission;
        em.enabled = true;
        em.rateOverTime = SliderEmitValue;

        var shape = ps.shape;
        shape.position = ShapePosition;
        shape.rotation = ShapeRotation;



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




        var velOverLife = ps.velocityOverLifetime;
        velOverLife.enabled = true;
        velOverLife.xMultiplier = SliderVeloLinearX;
        velOverLife.yMultiplier = SliderVeloLinearY;
        velOverLife.zMultiplier = SliderVeloLinearZ;
        velOverLife.orbitalXMultiplier = SliderVeloOrbX;
        velOverLife.orbitalYMultiplier = SliderVeloOrbY;
        velOverLife.orbitalZMultiplier = SliderVeloOrbZ;
        velOverLife.radialMultiplier = SliderVeloRadial;
        velOverLife.speedModifierMultiplier = SliderVelSpeed;

        var noise = ps.noise;
        noise.enabled = true;
        noise.separateAxes = true;
        noise.strengthXMultiplier = SliderNoiseXStrength;
        noise.strengthYMultiplier = SliderNoiseYStrength;
        noise.strengthZMultiplier = SliderNoiseZStrength;
        noise.frequency = SliderNoiseFrequency;
        noise.scrollSpeedMultiplier = SliderNoiseSpeed;
        noise.positionAmount = SliderNoisePosition;
        noise.rotationAmount = SliderNoiseRotation;
        noise.sizeAmount = SliderNoiseScale;
        noise.damping = damping;

        var limitVelocityOverLifetime = ps.limitVelocityOverLifetime;
        limitVelocityOverLifetime.limit = LimitVeloSpeed;
        limitVelocityOverLifetime.dampen = LimitVeloDampen;

        var sz = ps.sizeOverLifetime;
        sz.enabled = true;
        
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, .1f);
        curve.AddKey(0.75f, 1f);
        
        sz.size = new ParticleSystem.MinMaxCurve(SizeLife, curve);

    }   

}
