using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PlaceYouveBeen.Models;

namespace PlacesYouveBeen.Controllers
{
  public class PlacesController : Controller
  {
    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<Place> allPlaces = Place.GetAll();
      return View(allPlaces);
    }

    [HttpsGet("/places/new")]
    public ActionResults New()
    {
      return View();
    }

    [HttpPost("/places")]
    public ActionResult Create(string description)
    {
      Place myPlace = new Place(description);
      return RedirectToAction("Index");
    }

    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }

    [HttpGet("/places/{id}")]
    public ActionResult Show(int id)
    {
      Place foundPlace = Place.Find(id);
      return View(foundPlace);
    }
  }
}