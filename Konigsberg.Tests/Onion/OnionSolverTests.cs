using Konigsberg.Onion;
using static Konigsberg.Helpers.ResourceHelpers;

namespace Konigsberg.Tests.Onion;

[Trait("Category", nameof(Onion))]
public sealed class OnionSolverTests
{
    [Fact]
    public void LoadLayer0()
    {
        // arrange
        // act
        var layer = new Layer(ResourcePath("Onion", "layer0.txt"));

        // assert
        Assert.Equal("ASCII85", layer.Name);
        Assert.Equal(LayerLevel.Zero, layer.Level);
    }

    [Fact]
    public void SolveLayer0()
    {
        // arrange
        var layer0 = new Layer(ResourcePath("Onion", "layer0.txt"));

        // act
        var layer1 = OnionSolver.Peel(layer0, ResourcePath("Onion", "layer1.txt"));

        // assert
        Assert.Equal("Bitwise Operations", layer1.Name);
        Assert.Equal(LayerLevel.One, layer1.Level);
    }
}