using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oompe.lib;
using org.mariuszgromada.math.mxparser;

public class Method1 : MonoBehaviour
{
    // Constants defined for calculations
    private const double a1 = 126655.0 / 40000.0;  // a1 derived from registration number
    private const double f1 = 2.0;  // Frequency of the wave (in Hz)

    // Parameters for numerical integration using the rectangle method
    private const double startTime = 0.0;  // Starting point of the time interval for calculation
    private const double endTime = 20.0;  // Ending point of the time interval for calculation
    private const int intervals = 200; // Number of intervals

    void Start()
    {
        // Calculate the total energy using the rectangle method
        double totalEnergy = CalculateEnergyUsingRectangles(startTime, endTime, intervals);

        // Log the calculated total energy to the console
        Debug.Log($"Total Energy using Rectangle Method: {totalEnergy} Joules");
    }

    public double CalculateEnergyUsingRectangles(double start, double end, int numberOfIntervals)
    {
        // Calculate the width of each interval
        double intervalWidth = (end - start) / numberOfIntervals;
        double totalArea = 0.0;  // Initialize total area

        // Loop over each interval
        for (int i = 0; i < numberOfIntervals; i++)
        {
            double t = start + i * intervalWidth; // Current time for the left side of the rectangle
            double power = CalculatePowerAtTime(t); // Calculate power at the current time t
            totalArea += power * intervalWidth; // Add the area of the rectangle to the total area
        }

        return totalArea;  // Return the total calculated area, which represents total energy
    }

    double CalculatePowerAtTime(double time)
    {
        // Creating the power function P(t) using mXparser
        Argument t = new Argument("t", time);
        Expression powerExpr = new Expression($"({a1} * t) + sin(2 * pi * {f1} * t)", t);

        return powerExpr.calculate();  // Calculate & return power at a given time
    }
}