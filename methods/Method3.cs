using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class Method3 : MonoBehaviour
{
    // Constants defined for calculations
    private const double a1 = 126655.0 / 40000.0;  // a1 derived from registration number
    private const double f1 = 2.0;  // Frequency of the wave (in Hz)
    private const double startTime = 0.0;  // Starting point of the time interval for calculation
    private const double endTime = 20.0;  // Ending point of the time interval for calculation
    private const int intervals = 2000;  // Number of intervals

    void Start()
    {
        // Calculate the total energy using the trapezoidal method
        double totalEnergy = CalculateEnergyUsingTrapezoidalRule(startTime, endTime, intervals);

        // Log the calculated total energy to the console
        Debug.Log($"Total Energy using Trapezoidal Rule: {totalEnergy} Joules");
    }

    public double CalculateEnergyUsingTrapezoidalRule(double start, double end, int numberOfIntervals)
    {
        double h = (end - start) / numberOfIntervals;  // Calculate the width of each interval

        // Initialize the total area
        double totalArea = 0.5 * (CalculatePowerAtTime(start) + CalculatePowerAtTime(end));

        // Loop to calculate area for each trapezoid formed in the intervals
        for (int i = 1; i < numberOfIntervals; i++)
        {
            double x = start + i * h;  // Current time point in the interval
            totalArea += CalculatePowerAtTime(x);  // Adds area of each trapezoid to total area
        }
        
        // Final total area multiplied by interval width gives the total energy
        return totalArea * h;
    }

    double CalculatePowerAtTime(double time)
    {
        // Creating the power function P(t) using mXparser
        Argument t = new Argument("t", time);
        Expression powerExpr = new Expression($"({a1} * t) + sin(2 * pi * {f1} * t)", t);
        
        return powerExpr.calculate();  // Calculate & return power at a given time
    }
}