using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Repository;
namespace OnlineShop.Views
{
    public class GamesController : Controller
    {
        GameRepository Repository = new GameRepository();
        Game GameModel = new Game();
        // GET: Games
        public ActionResult Index()
        {
            var Prueba = Repository.ListGames();
           
            return View(Prueba.ToList()); 
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Repository.FindGameByID(id);
            GameModel = Repository.ListGames().Where(x => x.GameID == id).FirstOrDefault();
            if (Repository == null)
            {
                return HttpNotFound();
            }
            return View(GameModel);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,GameTittle,GameCategory,GameDetail")] Game game)
        {
            if (ModelState.IsValid)
            {
                Repository.RegisterGame(game);
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.FindGameByID(id);
            GameModel = Repository.ListGames().Where(x => x.GameID == id).FirstOrDefault();
            if (Repository == null)
            {
                return HttpNotFound();
            }
            return View(GameModel);
        }

        // POST: Games/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,GameTittle,GameCategory,GameDetail")] Game game)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateGameByID(game.GameID, game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repository.FindGameByID(id);
                
            GameModel = Repository.ListGames().Where(x => x.GameID == id).FirstOrDefault();

            if (Repository == null)
            {
                return HttpNotFound();
            }
            return View(GameModel);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.DeleteGame(id);
            return RedirectToAction("Index");
        }
        
    }
}
