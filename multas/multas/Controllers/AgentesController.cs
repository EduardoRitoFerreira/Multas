using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using multas.Models;

namespace multas.Controllers
{
    public class AgentesController : Controller
    {
        private MultasDb db = new MultasDb();

        // GET: Agentes
        public ActionResult Index()
        {
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Fotografia")] Agentes agente, HttpPostedFileBase fileUploadFotografia)
        {
            int novoID = 0;
            if (db.Agentes.Count() == 0)
            {
                novoID = 1;
            }
            else
            {
                novoID = db.Agentes.Max(a => a.ID) + 1;
            }
            //determinar o ID do novo Agente
           // int novoID = db.Agentes.Max(a => a.ID) + 1;
            //atribuir o ID ao novo agente
            agente.ID = novoID;
            //var. auxiliar
            string nomeFotografia = "Agente" + novoID + ".jpg";
            string caminhoParaFotografia = Path.Combine(Server.MapPath("~/imagens/"), nomeFotografia);
            //guardar o nome da imagem na BD
            agente.Fotografia = nomeFotografia;

            //verificar se chega efectivamente um ficheiro ao servidor
            if(fileUploadFotografia!=null){

            }
            else
            {
                ModelState.AddModelError("", "Não foi fornecida uma imagem");//gera msg de erro
                return View(agente);//reenvia os dados do agente para a view
            }
            //verificar se o ficheiro é realmente uma imagem ---> casa
            //redimensionar a imagem --> ver em casa
            //escrever a fotografia no disco rigido
            //escrever o nome da imagem na BD
        
            if (ModelState.IsValid)
            {
                try
                {
                db.Agentes.Add(agente);
                db.SaveChanges();
                //guardar a imagem no disco rigido
                fileUploadFotografia.SaveAs(caminhoParaFotografia);
                return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //gerar uma mansagem de erro para o utilizador
                    ModelState.AddModelError("", "Ocorreu um erro não determinado na criação do novo agente...");
                    throw;
                }
               
            }

            return View(agente);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Fotografia,Esquadra")] Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agentes);
        }

        // GET: Agentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agentes agentes = db.Agentes.Find(id);
            db.Agentes.Remove(agentes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
