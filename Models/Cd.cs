using System.Collections.Generic;

namespace CompactDisc.Models
{
  public class Cd
  {
    private string _title;
    private int _id;
    private static List<Cd> _myCds = new List<Cd> {};

    public Cd(string title)
    {
      _title = title;
      _myCds.Add(this);
      _id = _myCds.Count;
    }

    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string title)
    {
      _title = title;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Cd> GetAll()
    {
      return _myCds;
    }
    public static Cd Find(int searchId)
    {
      return _myCds[searchId - 1];
    }
  }
}
