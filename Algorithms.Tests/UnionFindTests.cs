using Xunit;
using Algorithms;

namespace Algorithms.Tests
{
  public class QuickUnionUF_Tests
  {
    [Fact]
    public void Constructor_InitializesCorrectly()
    {
      var uf = new QuickUnionUF(5);

      for (int i = 0; i < 5; i++)
      {
        Assert.Equal(i, uf.FindRoot(i));
      }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(9)]
    public void FindRoot_OnNewStructure_ReturnsSelf(int p)
    {
      var uf = new QuickUnionUF(10);

      Assert.Equal(p, uf.FindRoot(p));
    }

    [Fact]
    public void Union_ConnectsTwoElements()
    {
      var uf = new QuickUnionUF(10);

      uf.Union(2, 5);

      Assert.True(uf.Connected(2, 5));
    }

    [Fact]
    public void Connected_ReturnsFalse_WhenNotConnected()
    {
      var uf = new QuickUnionUF(10);

      uf.Union(1, 2);

      Assert.False(uf.Connected(1, 3));
    }

    [Fact]
    public void Union_CreatesTransitiveConnections()
    {
      var uf = new QuickUnionUF(10);

      uf.Union(2, 5);
      uf.Union(5, 7);

      Assert.True(uf.Connected(2, 7));
    }
  }
}