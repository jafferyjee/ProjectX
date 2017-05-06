using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectX.Web.Utility
{
    public static class HtmlHelperExtensions
    {
        public static XHtmlPanelComponent XPanelComponent(this HtmlHelper html, string title)
        {
            html.ViewContext.Writer.Write(
            "<div class=\"panel\">" +
            "<div class=\"panel-inner\">" +
            "<h2 class=\"panel-title\">" + title + "</h2>" +
            "<div class=\"panel-content\">"
            );

            return new XHtmlPanelComponent(html.ViewContext);
        }
    }

    public class XHtmlPanelComponent : IDisposable
    {
        private readonly ViewContext _viewContext;

        public XHtmlPanelComponent(ViewContext viewContext)
        {
            _viewContext = viewContext;
        }

        public void Dispose()
        {
            _viewContext.Writer.Write(
            "</div>" +
            "</div>" +
            "</div>"
            );
        }
    }
}