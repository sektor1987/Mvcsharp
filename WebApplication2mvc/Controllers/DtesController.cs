using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.Controllers
{
    public class DtesController : Controller
    {
        private DteEntidades db = new DteEntidades();

        // GET: Dtes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Dtes.ToList());
        }

        // GET: Dtes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dte dte = db.Dtes.Find(id);
            if (dte == null)
            {
                return HttpNotFound();
            }
            return View(dte);
        }

        // GET: Dtes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dtes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dte_id,dte_tipo_dte,dte_folio,dte_emisor,dte_receptor,dte_emisor_razonsocial,dte_receptor_razonsocial,dte_fecha_emision,dte_fecha_recepcion,dte_monto_total,dte_sii_estado,dte_sii_estado_desc,dte_tipo_distribucion,dte_acuse,dte_estado_comercial,dte_ws_descargado,dte_resp_cliente_cod,dte_resp_cliente_desc,dte_distribucion_cod,dte_distribucion_desc,dte_comercial_cod,dte_comercial_desc,dte_acuse_cod,dte_acuse_est,dte_url_custodia,dte_tipo_ingreso,dte_fch_venc,dte_vlr_codigo,dte_mnt_neto,dte_mnt_exe,dte_tasa_iva,dte_iva,dte_saldo_anterior,dte_vlr_pagar")] Dte dte)
        {
            if (ModelState.IsValid)
            {
                db.Dtes.Add(dte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dte);
        }

        // GET: Dtes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dte dte = db.Dtes.Find(id);
            if (dte == null)
            {
                return HttpNotFound();
            }
            return View(dte);
        }

        // POST: Dtes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dte_id,dte_tipo_dte,dte_folio,dte_emisor,dte_receptor,dte_emisor_razonsocial,dte_receptor_razonsocial,dte_fecha_emision,dte_fecha_recepcion,dte_monto_total,dte_sii_estado,dte_sii_estado_desc,dte_tipo_distribucion,dte_acuse,dte_estado_comercial,dte_ws_descargado,dte_resp_cliente_cod,dte_resp_cliente_desc,dte_distribucion_cod,dte_distribucion_desc,dte_comercial_cod,dte_comercial_desc,dte_acuse_cod,dte_acuse_est,dte_url_custodia,dte_tipo_ingreso,dte_fch_venc,dte_vlr_codigo,dte_mnt_neto,dte_mnt_exe,dte_tasa_iva,dte_iva,dte_saldo_anterior,dte_vlr_pagar")] Dte dte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dte);
        }

        // GET: Dtes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dte dte = db.Dtes.Find(id);
            if (dte == null)
            {
                return HttpNotFound();
            }
            return View(dte);
        }

        // POST: Dtes/Delete/5
        [HttpPost, ActionName("Delete")]
        
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dte dte = db.Dtes.Find(id);
            db.Dtes.Remove(dte);
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
