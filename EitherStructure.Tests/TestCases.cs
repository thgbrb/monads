using System;
using Xunit;

namespace EitherStructure.Tests;

public class TestCases
{
    [Fact(DisplayName = "Should return a string from a success usage case")]
    public void ShouldUsageSuccessCaseAndReturnString()
    {
        // Arrange
        var usageCases = new UsageCases();
        var value = "success case";

        // Act
        var result = usageCases
            .ReturnsStringOrArgumentNullException(value)
            .Match(
                success => $"{success}",
                error => $"{error}");

        // Assert
        Assert.Equal(value, result);
    }

    [Fact(DisplayName = "Should return a ArgumentNullException from an error usage case")]
    public void ShouldUsageFailCaseAndReturnArgumentNullException()
    {
        // Arrange
        var usageCases = new UsageCases();
        var expectedValue = "System.ArgumentNullException: Value cannot be null. (Parameter 'value')";

        // Act
        var result = usageCases
            .ReturnsStringOrArgumentNullException(null)
            .Match(
                success => $"{success}",
                error => $"{error}");

        // Assert
        Assert.True(result is not null);
        Assert.Equal(expectedValue, result);
    }

    [Fact(DisplayName = "Should throw an ArgumentNullExceptions for null left member")]
    public void ShouldThrowAnArgumentnullExceptionsForNullLeftMember()
    {
        // Arrange
        var usageCases = new UsageCases();

        // Act
        void TestCode()
        {
            usageCases.ReturnsArgumentNullExceptionForNullMembers()
                .Match<string>(null, error => $"{error}");
        }

        // Assert
        Assert.Throws<ArgumentNullException>(TestCode);
    }

    [Fact(DisplayName = "Should throw an ArgumentNullExceptions for null right member")]
    public void ShouldThrowAnArgumentnullExceptionsForNullRightMember()
    {
        // Arrange
        var usageCases = new UsageCases();

        // Act
        void TestCode()
        {
            usageCases.ReturnsArgumentNullExceptionForNullMembers()
                .Match<string>(success => success, null);
        }

        // Assert
        Assert.Throws<ArgumentNullException>(TestCode);
    }
}