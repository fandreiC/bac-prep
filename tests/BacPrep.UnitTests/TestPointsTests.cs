using BacPrep.Modules.Content.Domain;

namespace BacPrep.UnitTests.Content;

public sealed class TestPointsTests
{
    [Fact]
    public void PointsAreConsistentWhenEverythingAddsUp()
    {
        var test = CreateTest(sectionPoints: 30, exercisesPerSection: 6, exercisePoints: 5);

        Assert.True(test.PointsAreConsistent());
    }

    [Fact]
    public void PointsAreInconsistentWhenSectionsDoNotReach90()
    {
        var test = CreateTest(sectionPoints: 25, exercisesPerSection: 5, exercisePoints: 5);

        Assert.False(test.PointsAreConsistent());
    }

    [Fact]
    public void PointsAreInconsistentWhenExercisesDoNotMatchTheirSection()
    {
        var test = CreateTest(sectionPoints: 30, exercisesPerSection: 5, exercisePoints: 5);

        Assert.False(test.PointsAreConsistent());
    }

    private static Test CreateTest(int sectionPoints, int exercisesPerSection, int exercisePoints)
    {
        var test = new Test();
        for (var number = 1; number <= 3; number++)
        {
            var section = new Section { Number = number, MaxPoints = sectionPoints };
            for (var i = 0; i < exercisesPerSection; i++)
            {
                section.Exercises.Add(new Exercise { Label = "x", Statement = "x", MaxPoints = exercisePoints });
            }
            test.Sections.Add(section);
        }
        return test;
    }
}