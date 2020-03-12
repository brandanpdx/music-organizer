using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller
  {
    [HttpGet("/artist")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artist")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artist/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Album> artistAlbum = selectedArtist.Albums;
      model.Add("artist", selectedArtist);
      model.Add("album", artistAlbum);
      return View(model);
    }

    [HttpPost("artist/{artistId}/album")]
    public ActionResult Create(int artistId, string albumName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Album newAlbum = new Album(albumName);
      foundArtist.AddAlbum(newAlbum);
      List<Album> artistAlbum = foundArtist.Albums;
      model.Add("album", artistAlbum);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }


  }
}