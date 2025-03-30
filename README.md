# Finite Power Integration Project

## Introduction
This project entailed developing an algorithm to integrate a given power function over time, specifically tailored for an oscillating energy system. Using C# within the Unity environment, the project involved the application of numerical integration methods to calculate the energy consumed over a period of 20 seconds.

## Methodology
- **Numerical Integration**: Implemented three methods - Rectangle, Midpoint, and Trapezoidal Rule - to approximate the integral of the power function.
- **Error Analysis**: Calculated both absolute and relative errors to compare the numerical approximations against the analytically derived solution.
![eqn](./assets/images/UML.png)


## Results
- The project provided insights into the accuracy of different numerical integration techniques, with the Midpoint Method showing the highest precision.
- Visualization of function `P(t)` and the integration process were achieved through Unity, offering an interactive way to observe the behavior of the energy system.

## Technologies
- **C#**: Used for scripting the integration algorithms and error calculations.
- **Unity**: Employed for visualizations and interactive displays of results.

## Usage
- The repository contains all source codes and detailed instructions for running simulations and visualizations.
- The README also includes a breakdown of the error metrics and their significance in evaluating the accuracy of numerical methods.
