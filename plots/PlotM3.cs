using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class PlotM3 : MonoBehaviour
{
    private FunctionPlotter fp;  // Variable to hold the function plotter
    private Function F;  // Variable to represent the function to be plotted


    public void RunTest()
    {
        // Initialize the function F with the given mathematical expression
        F = new Function("P(t) = ((126655.0/40000.0) * t) + sin(2 * pi * 2 * t)");

        // Initialize the function plotter with function F, plotting from 0 to 20 on the x-axis
        fp = new FunctionPlotter(F, 0, 20);

        // Define the interval width for plotting
        double intervalWidth = 0.1;

        // Loop to plot the function
        for (double i = 0; i <= 20 - intervalWidth; i += intervalWidth)
        {
            // Calculate function values at the start & end of the interval
            double fx0 = F.calculate(i);
            double fx1 = F.calculate(i + intervalWidth);

            // Add lines for linear interpolation between points (fx0, fx1)
            fp.AddLine(new Vector2((float)i, (float)fx0), new Vector2((float)(i + intervalWidth), (float)fx1));

            // Add vertical lines to the x-axis from each point for better visualization
            fp.AddLine(new Vector2((float)i, (float)0), new Vector2((float)(i), (float)fx0));
            fp.AddLine(new Vector2((float)(i + intervalWidth), (float)0), new Vector2((float)(i + intervalWidth), (float)fx1));
        }

        // Plot the function onto the GameObject using the FunctionPlotter
        fp.Plot(this.gameObject);
    }

    void Start()
    {
        RunTest();
    }
}