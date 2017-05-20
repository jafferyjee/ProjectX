using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ProjectX.Service;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Web.Utility;
using ProjectX.Web.Areas.Definitions.Models;
using System.Threading.Tasks;
using System.Web.Http;
using ProjectX.Entities.Models;
using Repository.Pattern.Infrastructure;

namespace ProjectX.Web.Areas.Definitions.Controllers
{
    public class ItemController : Controller, IDisposable
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IItemService _itemService;

        public ItemController(IUnitOfWorkAsync unitOfWork, IItemService itemService)
        {
            _unitOfWorkAsync = unitOfWork;
            _itemService = itemService;
        }

        // GET: Definitions/Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUpdate(string id) 
        {
            if (string.IsNullOrEmpty(id))
                return View(new ItemModel());

            ItemModel model = Mappings.ToModel(_itemService.Queryable().Where(i => i.ItemFullCode == id).FirstOrDefault());
            model.isEditMode = true;

            return View(model);
        }

        #region Grid Methods

        //public ActionResult Item_Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    return Json(_itemService.Queryable().OrderBy(i => i.ItemFullCode).ToDataSourceResult(request));
        //}

        #endregion

        #region Crud Methods

        //public async Task<ActionResult> Save([FromBody] ItemModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    Item item = Mappings.ToEntity(model);
        //    item.ObjectState = ObjectState.Modified;
        //    _itemService.Update(item);

        //    try
        //    {
        //        await _unitOfWorkAsync.SaveChangesAsync();
        //    }
        //    catch (Exception ex) 
        //    {
        //        if (!ItemExists(model.ItemFullCode))
        //            return NotFound();

        //        throw;
        //    }
        //}

        #endregion

        #region Private Methods

        private bool ItemExists(string key)
        {
            return _itemService.Query(i => i.ItemFullCode == key).Select().Any();
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