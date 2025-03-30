using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class PlotFunction : MonoBehaviour
{
    private Function powerFunction;
    private FunctionPlotter plotter;
    
    // value of a1 cal according from registration number & given f1 value
    private float a1 = 3.167f;
    private float f1 = 2.0f;

    public void RunTest()
    {
        // Power function using a string expression
        string functionExpression = $"f(t) = {a1}*t + sin(2*pi*{f1}*t)";
        powerFunction = new Function(functionExpression);

        // FunctionPlotter with the function and the range
        plotter = new FunctionPlotter(powerFunction, 0, 20.0f);
        
        plotter.Plot(this.gameObject);

    }

    void Start()
    {
        RunTest();
    }
}
