using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class AlbumController : Controller
  {
    [HttpGet("/artist/{artistId}/album/{albumId}")]
    public ActionResult Show(int artistId, int albumId)
    {
      Album album = Album.Find(albumId);
      Artist artist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpGet("/artist/{artistId}/album/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpPost("/artist/{artistId}/album/delete")]
    public ActionResult DeleteAll(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      artist.ClearAll();
      return RedirectToAction("Show");
    }


  }
}