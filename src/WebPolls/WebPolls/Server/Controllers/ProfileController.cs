using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebPolls.Server.Controllers
{
  public class ProfileController : Controller
  {
    // GET: ProfileController
    public ActionResult Index()
    {
      return View();
    }

 

    // POST: ProfileController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: ProfileController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }
 
  }
}
