using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation
{
    public int temp;
    public int ph;
    public int generation;
    public int gen;
    public float time;
    public Generation(int _temp, int _ph, int _generation, int _gen, float _time)
    {
        this.temp = _temp;
        this.ph = _ph;
        this.generation = _generation;
        this.gen = _gen;
        this.time = _time;
    }
}
