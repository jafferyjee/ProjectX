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
                "<div class=\"x_panel\">" +
                    "<div class=\"x_title\">" +
                        "<h2>" + title + "</h2>" +
                        "<ul class=\"nav navbar-right panel_toolbox\">" +
                            "<li>" +
                                "<a class=\"collapse-link\"><i class=\"fa fa-chevron-up\"></i></a>" +
                            "</li>" +
                            "<li class=\"dropdown\">" +
                                "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" role=\"button\" aria-expanded=\"false\"><i class=\"fa fa-wrench\"></i></a>" +
                                "<ul class=\"dropdown-menu\" role=\"menu\">" +
                                    "<li>" +
                                        "<a href=\"#\">Settings 1</a>" +
                                    "</li>" +
                                    "<li>" +
                                        "<a href=\"#\">Settings 2</a>" +
                                    "</li>" +
                                "</ul>" +
                            "</li>" +
                            "<li>" +
                                "<a class=\"close-link\"><i class=\"fa fa-close\"></i></a>" +
                            "</li>" +
                        "</ul>" +
                        "<div class=\"clearfix\"></div>" +
                    "</div>"
            );

            return new XHtmlPanelComponent(html.ViewContext);
        }

        public static XHtmlPageComponent XPageComponent(this HtmlHelper html, string title) 
        {
            html.ViewContext.Writer.Write(
                "<div class=\"page-title\">" +
                    "<div class=\"title_left\">" +
                        "<h3>" + title + "</h3>" +
                    "</div>" +
                    "<div class=\"title_right\">" +
                        "<div class=\"col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search\">" +
                            "<div class=\"input-group\">" +
                                "<input type=\"text\" class=\"form-control\" placeholder=\"Search for...\">" +
                                "<span class=\"input-group-btn\">" +
                                    "<button class=\"btn btn-default\" type=\"button\">Go!</button>" +
                                "</span>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>" +
                "<div class=\"clearfix\"></div>" 
                );

            return new XHtmlPageComponent(html.ViewContext);
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
                "</div>"
            );
        }
    }

    public class XHtmlPageComponent : IDisposable 
    {
        private readonly ViewContext _viewContext;

        public XHtmlPageComponent(ViewContext viewContext)
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