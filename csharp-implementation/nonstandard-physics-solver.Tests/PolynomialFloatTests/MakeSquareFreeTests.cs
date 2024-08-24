﻿namespace NonstandardPhysicsSolver.Tests.PolynomialFloatTests;

using NonstandardPhysicsSolver.Tests.TestUtils;
using Xunit;

public class MakeSquareFreeTests
{
    private static void AssertSquareFreeTransformation(float[] originalCoefficients, float[] expectedCoefficients)
    {
        // Arrange
        var polynomial = new PolynomialFloat(originalCoefficients);

        // Act
        var squareFreePolynomial = polynomial.MakeSquarefree();
        var actualCoefficients = PolynomialUtils.NormalizedCoefficients(squareFreePolynomial);

        // Assert
        AssertExtensions.ArraysApproximatelyEqual(expectedCoefficients, actualCoefficients);
    }

    [Fact]
    public void TestMakeSquareFree()
    {
        AssertSquareFreeTransformation([1f, 0f, 1f], [1f, 0f, 1f]);
    }

    [Fact]
    public void TestWithNonSquareFreePolynomial()
    {
        AssertSquareFreeTransformation([4f, 0f, -4f, 0f, 1f], [-2f, 0f, 1f]);
    }

    [Fact]
    public void TestWithHighDegreePolynomialWithMultipleSquareFactors()
    {
        AssertSquareFreeTransformation([1f, -2f, 1f, 0f, 0f, 0f, 1f], [1f, -2f, 1f, 0f, 0f, 0f, 1f]);
    }

    [Fact]
    public void TestWithPolynomialPerfectSquare()
    {
        AssertSquareFreeTransformation([0f, 0f, 1f], [0, 1f]);
    }
}
