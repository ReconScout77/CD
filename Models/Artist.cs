using System.Collections.Generic;

namespace CompactDisc.Models
{
  public class Artist
  {
    private string _name;
    private int _id;
    private static List<Artist> _artists = new List<Artist> {};
    private List<Cd> _cds;


    public Artist(string name)
    {
      _name = name;
      _artists.Add(this);
      _id = _artists.Count;
      _cds = new List<Cd> {};
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetId()
    {
      return _id;
    }
    public static Artist Find(int thatId)
    {
      return _artists[thatId - 1];
    }
    public static List<Artist> GetAll()
    {
      return _artists;
    }
    public List<Cd> GetCds()
    {
      return _cds;
    }
    public void AddCd(Cd cd)
    {
      _cds.Add(cd);
    }
  }
}
