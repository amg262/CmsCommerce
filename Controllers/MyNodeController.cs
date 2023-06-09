﻿using CmsCommerce.Business.SupportingClasses;
using CmsCommerce.Models.Catalog;
using EPiServer.Commerce.Catalog;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Controllers
{
    public class MyNodeController : MyControllerBase<MyNode>
    {
        public MyNodeController(IContentLoader contentLoader, UrlResolver urlResolver,
            AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver) : base(contentLoader,
            urlResolver, assetUrlResolver, thumbnailUrlResolver)
        {
        }

        public ActionResult Index(MyNode currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var nodeEntryCombo = new NodeEntryCombo
            {
                Nodes = GetNodes(currentPage.ContentLink),
                Entries = base.GetEntries(currentPage.ContentLink)
            };
            return View(nodeEntryCombo);
        }
    }
}