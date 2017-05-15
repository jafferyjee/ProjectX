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

namespace ProjectX.Web.Areas.Definitions.Controllers
{
    public class ArticleController : Controller, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemService _itemService;

        public ArticleController(IUnitOfWork unitOfWork, IItemService itemService)
        {
            _unitOfWork = unitOfWork;
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

            return View(model);
        }

        #region Grid Methods

        public ActionResult Item_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_itemService.Queryable().OrderBy(i => i.ItemFullCode).ToDataSourceResult(request));
        }

        #endregion

        #region Crud Methods
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
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}