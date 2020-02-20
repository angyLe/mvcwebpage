﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class PagingHelpers
    {
       public static MvcHtmlString PageLinks(this HtmlHelper html,
       PagingInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                   // tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("menulink-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }
}