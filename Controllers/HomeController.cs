using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CompactDisc.Models;
using System;

namespace CompactDisc.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/artists")]
    public ActionResult Artists()
    {
      List<Artist> artists = Artist.GetAll();
      return View(artists);
    }

    [HttpGet("/artistform")]
    public ActionResult ArtistForm()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult AddArtist()
    {
      Artist newArtist = new Artist(Request.Form["artist-input"]);
      List<Artist> artists = Artist.GetAll();
      return View("artists", artists);
    }

    [HttpGet("/artistDetails/{id}")]
    public ActionResult ArtistDetails(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Cd> artistCds = selectedArtist.GetCds();
      model.Add("artist", selectedArtist);
      model.Add("cds", artistCds);
      return View(model);
    }

    [HttpGet("/artistDetails/{id}/new")]
    public ActionResult CdForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Cd> artistCds = Cd.GetAll();
      model.Add("artist", selectedArtist);
      model.Add("cdList", artistCds);
      return View(model);
    }

    [HttpGet("/cdList")]
    public ActionResult CdList()
    {
      List<Cd> newList = Cd.GetAll();
      return View(newList);
    }

    [HttpPost("/cds")]
    public ActionResult AddCd()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(Int32.Parse(Request.Form["selectedArtist"]));
      List<Cd> artistCds = selectedArtist.GetCds();
      Cd cd = new Cd(Request.Form["cd-input"]);
      artistCds.Add(cd);
      model.Add("cds", artistCds);
      model.Add("artist", selectedArtist);
      return View("ArtistDetails", model);
    }

    [HttpGet("/CdDetails/{id}")]
    public ActionResult CdDetails(int id)
    {
      Cd cd = Cd.Find(id);
      return View(cd);
    }
  }
}
