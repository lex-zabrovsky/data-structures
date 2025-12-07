using System.Runtime.CompilerServices;

namespace Algorithms
{
  /// <summary>
  /// Quick-find implementation. The data structure supporting
  /// the algorithm is an integer array <c>id: int[size]</c> indexed 
  /// by object. Those objects--P and Q--are connected if and only
  /// if, their entries in the array are the same: 
  /// <code>P, Q IS CONNECTED => id[P] == id[Q]</code>
  /// </summary>
  public class QuickFindUF
  {
    private readonly int[] id;

    /// <summary>
    /// This method is Quick-find algoritm constructor. By instantiation, 
    /// this initializes an id array of size <c>size</c> to hold a data 
    /// structure supporting Quick-find algorith.
    /// 
    /// <example>
    /// Instantiation example:
    /// <code>
    /// var qf = new QuickFindUF(10);
    /// </code>
    /// </example>
    /// 
    /// </summary>
    /// <param name="size"></param>
    public QuickFindUF(int size)
    {
      id = new int[size];

      for (int i = 0; i < size; i++)
        id[i] = i;
    }

    /// <summary>
    /// Connects element P from one connected component to element
    /// Q from some connected component.
    /// Merges components of <c>id</c> component array containing
    /// P and Q by changing all entries whose ids equals 
    /// <c>id[p]</c> to <c>id[q]</c>.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    public void Union(int p, int q)
    {
      int pValue = id[p];
      int qValue = id[q];

      for (int i = 0; i < id.Length; i++)
        if (id[i] == pValue) id[i] = qValue;
    }

    public bool Connected(int p, int q)
    {
      return id[p] == id[q];
    }

    public override string ToString()
    {
      return string.Join(separator: "", values: id);
    }
  }

  /// <summary>
  /// In QuickUnionUF <c>int[] id</c> array representing a SET OF TREES that's
  /// called a FOREST. Each entry in an array contains the reference to its
  /// parent. ROOT: id[x] == x.
  /// </summary>
  public class QuickUnionUF
  {
    // stores the parent pointers.
    private readonly int[] id;

    public QuickUnionUF(int size)
    {
      id = new int[size];

      for (int i = 0; i < size; i++)
        id[i] = i;
    }

    /// <summary>
    /// Chases for a parent of the P'th entry.
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public int FindRoot(int p)
    {
      while (p != id[p])
      {
        p = id[p];
      }
      return p;
    }

    /// <summary>
    /// Chase the ROOTs of P and Q. Check if they have the same ROOT.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    /// <returns></returns>
    public bool Connected(int p, int q)
    {
      return FindRoot(p) == FindRoot(q);
    }

    /// <summary>
    /// Connect P componets's ROTT to Q's component ROOT.
    /// Find ROOTs of both, update P's pointer for new ROOT.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="q"></param>
    public void Union(int p, int q)
    {
      int rootP = FindRoot(p);
      int rootQ = FindRoot(q);

      id[rootP] = rootQ;
    }

    public override string ToString()
    {
      return string.Join("", id);
    }
  }
}