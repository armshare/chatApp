using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return Redirect("/");
            }

            ViewBag.currentUser = Session["user"];
            return View();
        }

        [HttpPost]
        public ActionResult Typing()
        {
            string typer = Request.Form["typer"];
            string socket_id = Request.Form["socket_id"];

            var options = new PusherOptions
            {
                Cluster = "ap1",
                Encrypted = true
            };

            var pusher = new Pusher(
              "548750",
              "8c290a9d0ed6bbacf5c5",
              "68ca4df8504b827cc9bc",
              options);
            

            pusher.TriggerAsync(
                 "chat",
                 "typing",
                 new { typer = typer },
                 new TriggerOptions() { SocketId = socket_id });



            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }
    }
}