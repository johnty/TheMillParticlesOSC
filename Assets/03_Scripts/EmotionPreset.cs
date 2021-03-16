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
        preset.ShapePos = new Vector3(0, 0, 850);
        preset.Color1 = new Vector3(1, 1, 0);
        preset.Color2 = new Vector3(1.15f, 0.3f, 0);
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
        preset.ShapePos = new Vector3(0, 0, 1000);
        preset.Color1 = new Vector3(0.2f, 1f, 0.6f);
        preset.Color2 = new Vector3(0, 0.3f, 0.15f);
        preset.VeloLin = new Vector3(-0.7f, 0.758f, -0.758f);
        preset.VeloOrb = new Vector3(0, 0, 0);
        preset.VeloRad = 0;
        preset.VeloSpd = 0.33f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(13, 3, -6);
        preset.NoiseFrq = 0.00151f;
        preset.NoiseSpd = 0.68f;
        preset.NoisePos = -9.1f;
        preset.NoiseRot = 0.3f;
        preset.NoiseScl = 0.8f;
        preset.SizeLif = 0.6f;

        preset.EmoCoords = new Vector2(1, -1);

        return preset;
    }

    public static EmotionPreset getSad()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 850);
        preset.Color1 = new Vector3(0.1f, 0.11f, 0.5f);
        preset.Color2 = new Vector3(0, 0.12f, 0.2f);
        preset.VeloLin = new Vector3(3, 50, -50);
        preset.VeloOrb = new Vector3(0.8f, 1.09f, 0.42f);
        preset.VeloRad = -30;
        preset.VeloSpd = 0.1f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(-60, 0, 0);
        preset.NoiseFrq = 0.003f;
        preset.NoiseSpd = 10;
        preset.NoisePos = 3;
        preset.NoiseRot = 0;
        preset.NoiseScl = 0.5f;
        preset.SizeLif = 0.6f;

        preset.EmoCoords = new Vector2(-1, -1);

        return preset;
    }

    public static EmotionPreset getAnger()
    {
        EmotionPreset preset = new EmotionPreset();
        preset.ShapePos = new Vector3(0, 0, 800);
        preset.Color1 = new Vector3(0.2f, -0.42f, 0f);
        preset.Color2 = new Vector3(1f, 0.04f, 0f);
        preset.VeloLin = new Vector3(0.03f, 0, -50f);
        preset.VeloOrb = new Vector3(0, 0, 0.15f);
        preset.VeloRad = -30;
        preset.VeloSpd = 3.73f;
        preset.VeloLimSpd = 0;
        preset.VeloDmp = 0;
        preset.NoiseStr = new Vector3(29f, 32f, -16f);
        preset.NoiseFrq = 0.005f;
        preset.NoiseSpd = 5;
        preset.NoisePos = 3.6f;
        preset.NoiseRot = 0.5f;
        preset.NoiseScl = 0.433f;
        preset.SizeLif = 0.48f;

        preset.EmoCoords = new Vector2(-1, 1);

        return preset;
    }


}
