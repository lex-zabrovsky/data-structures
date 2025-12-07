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
      string result = "";
      foreach (var i in id)
        result += id[i].ToString();

      return result;
    }
  }
}