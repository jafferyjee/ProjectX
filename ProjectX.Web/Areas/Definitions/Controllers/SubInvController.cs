using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ProjectX.Service;
using ProjectX.Web.Utility;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Web.Areas.Definitions.Models;
using ProjectX.Entities.Models;
using Repository.Pattern.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace ProjectX.Web.Areas.Definitions.Controllers
{
    public class SubInvController : Controller, IDisposable
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ISubInventoryService _subInventoryService;

        public SubInvController(
                IUnitOfWorkAsync unitOfWorkAsync,
                ISubInventoryService subInventoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _subInventoryService = subInventoryService;
        }

        #region Page Methods

        //
        // GET: /Definitions/SubInv/
        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult GetSubInv()
        {
            return Json(_subInventoryService.Queryable().OrderBy(s => s.SubInvCode), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Grid Methods

        public ActionResult SubInv_Read([DataSourceRequest] DataSourceRequest request)
        {
            //Mappings.ToModel(_subInventoryService.Queryable().OrderBy(s => s.SubInvCode));
            return Json(_subInventoryService.Queryable().OrderBy(s => s.SubInvCode).ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubInv_Create([DataSourceRequest] DataSourceRequest request, SubInvModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                SubInventory subinv = Mappings.ToEntity(model);
                subinv.ObjectState = ObjectState.Added;
                subinv.CreatedBy = subinv.ModifiedBy = "I-ALI";
                subinv.CreatedDate = subinv.ModifiedDate = DateTime.Now;

                _subInventoryService.Insert(subinv);

                try
                {
                     _unitOfWorkAsync.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(subinv.SubInvCode))
                        throw new Exception("Item already exists.");

                    throw;
                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubInv_Update([DataSourceRequest] DataSourceRequest request, SubInvModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                //productService.Update(model);
                SubInventory subinv = Mappings.ToEntity(model);
                subinv.ObjectState = ObjectState.Modified;
                subinv.ModifiedBy = "I-ALI";
                subinv.ModifiedDate = DateTime.Now;

                _subInventoryService.Update(subinv);

                try
                {
                    _unitOfWorkAsync.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(model.SubInvCode))
                        throw new Exception("Item does not exist.");

                    throw;
                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubInv_Destroy([DataSourceRequest] DataSourceRequest request, SubInvModel model)
        {
            if (model != null)
            {
                //productService.Destroy(model);
                SubInventory subinv = _subInventoryService.Find(model.SubInvCode);

                if (subinv == null)
                    throw new Exception("Item does not exist.");

                subinv.ObjectState = ObjectState.Deleted;

                _subInventoryService.Delete(subinv);

                _unitOfWorkAsync.SaveChanges();
           }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Private Methods

        private bool ItemExists(string key)
        {
            return _subInventoryService.Query(i => i.SubInvCode == key).Select().Any();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
