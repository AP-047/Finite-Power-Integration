using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class PlotM1 : MonoBehaviour
{
    private FunctionPlotter fp;  // Variable to hold the function plotter
    private Function F;  // Variable to represent the function to be plotted
    
    public void RunTest()
    {
        // Initialize the function F with the given mathematical expression
        F = new Function("P(t) = ((126656/40000) * t) + sin(2 * pi * 2 * t)");
        
        // Initialize the function plotter with function F, plotting from 0 to 20 on the x-axis
        fp = new FunctionPlotter(F, 0, 20);
        
        // Define the interval width for plotting
        double intervalWidth = 1.0;

        // Loop to plot the function as a series of rectangles
        for (double i = 0; i <= 20; i += intervalWidth)
        {
            // Calculate the function value at the current point
            double fx = F.calculate(i);
            
            // Add rectangle data to the FunctionPlotter
            // Each rectangle is represented by three lines: two vertical & one horizontal
            fp.AddLine(new Vector2((float)i, 0), new Vector2((float)i, (float)fx));
            fp.AddLine(new Vector2((float)i, (float)fx), new Vector2((float)(i + intervalWidth), (float)fx));
            fp.AddLine(new Vector2((float)(i + intervalWidth), (float)fx), new Vector2((float)(i + intervalWidth), 0));
        }
        
        // Plot the function onto the GameObject using the FunctionPlotter
        fp.Plot(this.gameObject);
    }

    void Start()
    {
        RunTest();
    }
}