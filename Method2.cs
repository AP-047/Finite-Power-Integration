using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class Method2 : MonoBehaviour
{
    // Constants defined for calculations
    private const double a1 = 126655.0 / 40000.0;  // a1 derived from registration number
    private const double f1 = 2.0;   // Frequency of the wave (in Hz)
    private const double startTime = 0.0;  // Starting point of the time interval for calculation
    private const double endTime = 20.0;  // Ending point of the time interval for calculation
    private const int intervals = 50;  // Number of intervals

    void Start()
    {
        // Calculate the total energy using the midpoint method
        double totalEnergy = CalculateEnergyUsingMidpointMethod(startTime, endTime, intervals);

        // Log the calculated total energy to the console
        Debug.Log($"Total Energy using Midpoint Method: {totalEnergy} Joules");
    }

    public double CalculateEnergyUsingMidpointMethod(double start, double end, int numberOfIntervals)
    {
        double intervalWidth = (end - start) / numberOfIntervals;  // Calculate the width of each interval
        double totalArea = 0.0;  // Initialize total area to 0

        // Loop over each interval
        for (int i = 0; i < numberOfIntervals; i++)
        {
            double midpoint = start + (i + 0.5) * intervalWidth;  // Calculate the midpoint of each interval
            double midpointHeight = CalculatePowerAtTime(midpoint);  // Calculate the power at the midpoint
            totalArea += midpointHeight * intervalWidth;  // Multiply by interval width and add to total area
        }

        return totalArea;  // Return the total calculated area, which represents the total energy
    }

    double CalculatePowerAtTime(double time)
    {
        // Creating the power function P(t) using mXparser
        Argument t = new Argument("t", time);
        Expression powerExpr = new Expression($"({a1} * t) + sin(2 * pi * {f1} * t)", t);

        return powerExpr.calculate();  // Calculate & return power at a given time
    }
}
