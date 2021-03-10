using System;
using UnityEngine;

public class EmotionPreset
{
    public enum EmoPreset
    {
        JOY,
        CALM,
        SAD,
        ANGER
    };

    public Vector3 Color1;
    public Vector3 Color2;
    public Vector3 ShapePos;
    public Vector3 VeloLin;
    public Vector3 VeloOrb;
    public float VeloRad;
    public float VeloSpd;
    public float VeloLimSpd;
    public float VeloDmp;
    public Vector3 NoiseStr;
    public float NoiseFrq;
    public float NoiseSpd;
    public float NoisePos;
    public float NoiseRot;
    public float NoiseScl;
    public float SizeLif;

    public Vector2 EmoCoords;

    public EmotionPreset()
    {

    }

    public static EmotionPreset interpPreset(Vector2 coords)
    {
        EmotionPreset res = new EmotionPreset();

        EmotionPreset[] emotions = new EmotionPreset[4];

        emotions[0] = getCalm();
        emotions[1] = getJoy();
        emotions[2] = getSad();
        emotions[3] = getAnger();

        res = interpPresetFromArray(emotions, coords);

        return res;
    }

    //go through a list of emotion presets, and return the weighted interpolation
    // of preset values based on inverse square distance from current coords
    public static EmotionPreset interpPresetFromArray(EmotionPreset[] emos, Vector2 coords)
    {
        EmotionPreset res = new EmotionPreset();
        float[] weights = new float[emos.Length];
        float sum = 0;
        for (int i= 0; i < emos.Length; i++)
        {
            float dx = coords.x - emos[i].EmoCoords.x;
            float dy = coords.y - emos[i].EmoCoords.y;
            weights[i] = 1/(float)Math.Sqrt(Math.Pow(dx, 2)+Math.Pow(dy, 2)+0.001); //prevent NaN when we're on top of a coord
            sum += weights[i];
        }
        for (int i=0; i< emos.Length; i++)
        {
            weights[i] = weights[i] / sum;
            Debug.Log("weight " + i.ToString() + " = " + weights[i].ToString());
        }

        for (int i=0; i< emos.Length; i++)
        {
            float w = weights[i];
            res.Color1 += emos[i].Color1 * w;
            res.Color2 += emos[i].Color2 * w;
            res.ShapePos += emos[i].ShapePos * w;
            res.VeloLin += emos[i].VeloLin * w;
            res.VeloOrb += emos[i].VeloOrb * w;
            res.VeloRad += emos[i].VeloRad * w;
            res.VeloSpd += emos[i].VeloSpd * w;
            res.VeloLimSpd += emos[i].VeloLimSpd * w;
            res.VeloDmp += emos[i].VeloDmp * w; //NOTE: is this supposed to be on/off?
            res.NoiseStr += emos[i].NoiseStr * w;
            res.NoiseFrq += emos[i].NoiseFrq * w;
            res.NoiseSpd += emos[i].NoiseSpd * w;
            res.NoisePos += emos[i].NoisePos * w;
            res.NoiseRot += emos[i].NoiseRot * w;
            res.NoiseScl += emos[i].NoiseScl * w;
            res.SizeLif += emos[i].SizeLif * w;

        }
        

        return res;
    }

    public EmotionPreset GetPreset(EmoPreset emo = EmoPreset.CALM)
    {
        switch (emo)
        {
            case EmoPreset.JOY:
                return getJoy();
            case EmoPreset.CALM:
                return getCalm();
            case EmoPreset.SAD:
                return getSad();
            case EmoPreset.ANGER:
                return getAnger();
                
            default:
                return getCalm();
        }
    }

    //from table

    // JOY is 1, 1
    public static EmotionPreset getJoy()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 450);
        preset.Color1 = new Vector3(1, 1, 0);
        preset.Color2 = new Vector3(1, 0, 0);
        preset.VeloLin = new Vector3(0, 0, 0);
        preset.VeloOrb = new Vector3(0.98f, 0.87f, 0);
        preset.VeloRad = -30;
        preset.VeloSpd = 1;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(10, 0, 53);
        preset.NoiseFrq = 0.0047f;
        preset.NoiseSpd = 0;
        preset.NoisePos = 20;
        preset.NoiseRot = 1;
        preset.NoiseScl = 0.5f;
        preset.SizeLif = 0.8f;

        preset.EmoCoords = new Vector2(1,1);

        return preset;
    }

    public static EmotionPreset getCalm()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 400);
        preset.Color1 = new Vector3(0, 0.06f, 1);
        preset.Color2 = new Vector3(0.05f, 0.1f, 0.4f);
        preset.VeloLin = new Vector3(50, 0, 0);
        preset.VeloOrb = new Vector3(0.5f, 0, 0.3f);
        preset.VeloRad = 0;
        preset.VeloSpd = 0.1f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(10, 30, -70);
        preset.NoiseFrq = 0.0015f;
        preset.NoiseSpd = 0.5f;
        preset.NoisePos = -4.2f;
        preset.NoiseRot = 0.3f;
        preset.NoiseScl = 0.8f;
        preset.SizeLif = 1.9f;

        preset.EmoCoords = new Vector2(1, -1);

        return preset;
    }

    public static EmotionPreset getSad()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 450);
        preset.Color1 = new Vector3(0.21f, 0, 0.45f);
        preset.Color2 = new Vector3(0, 0, 0.39f);
        preset.VeloLin = new Vector3(3, 50, -50);
        preset.VeloOrb = new Vector3(0.8f, 1.09f, 0.42f);
        preset.VeloRad = -30;
        preset.VeloSpd = 0.1f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(-100, 0, 0);
        preset.NoiseFrq = 0.003f;
        preset.NoiseSpd = 10;
        preset.NoisePos = 3;
        preset.NoiseRot = 0;
        preset.NoiseScl = 0.9f;
        preset.SizeLif = 0.5f;

        preset.EmoCoords = new Vector2(-1, -1);

        return preset;
    }

    public static EmotionPreset getAnger()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 0);
        preset.Color1 = new Vector3(0.48f, 0, 1.14f);
        preset.Color2 = new Vector3(0, 3.14f, 0);
        preset.VeloLin = new Vector3(0, 0, 0);
        preset.VeloOrb = new Vector3(0, 0.16f, 0.15f);
        preset.VeloRad = -30;
        preset.VeloSpd = 1.31f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(8, 0, -4);
        preset.NoiseFrq = 0.005f;
        preset.NoiseSpd = 5;
        preset.NoisePos = -7;
        preset.NoiseRot = 0.5f;
        preset.NoiseScl = 0.248f;
        preset.SizeLif = 1.26f;

        preset.EmoCoords = new Vector2(-1, 1);

        return preset;
    }


}
