using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class PlotM2 : MonoBehaviour

{
    private FunctionPlotter fp;  // Variable to hold the function plotter
    private Function F;  // Variable to represent the function to be plotted

    public void RunTest()
    {
        // Initialize the function F with the given mathematical expression
        F = new Function("P(t) = ((126656.0/40000.0) * t) + sin(2 * pi * 2 * t)");
        
        // Initialize the function plotter with function F, plotting from 0 to 20 on the x-axis
        fp = new FunctionPlotter(F, 0, 20);

        // Define the interval width for plotting
        double intervalWidth = 20 / 20;

        // Loop to plot the function
        for (double i = 0; i <= 20 - intervalWidth; i += intervalWidth)
        {
            // Calculate function values at the start & end of the interval
            double fx0 = F.calculate(i);
            double fx1 = F.calculate(i + intervalWidth);
            double averageFx = (fx0 + fx1) / 2.0;

            // Add vertical lines from x-axis to the average function value
            fp.AddLine(new Vector2((float)i, 0), new Vector2((float)i, (float)averageFx));

            // Add horizontal lines at the average function value
            fp.AddLine(new Vector2((float)i, (float)averageFx), new Vector2((float)(i + intervalWidth), (float)averageFx));

            // Add vertical lines from the end of the interval back to x-axis
            fp.AddLine(new Vector2((float)(i + intervalWidth), (float)averageFx), new Vector2((float)(i + intervalWidth), 0));
        }

        // Plot the function onto the GameObject using the FunctionPlotter
        fp.Plot(this.gameObject);
    }

    void Start()
    {
        RunTest();
    }
}