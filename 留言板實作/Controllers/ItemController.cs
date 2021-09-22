using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 留言板實作.Services;
using 留言板實作.ViewModels;

namespace 留言板實作.Controllers
{
    public class ItemController : Controller
    {
        ItemService itemService = new ItemService();
        CartDBService cartService = new CartDBService();

        //商品清單頁
        public ActionResult Index(int page = 1)
        {
            ItemListViewModel itemList = new ItemListViewModel();
            itemList.Page = new Paging(page);
            itemList.IdList = itemService.GetIDList(itemList.Page);
            itemList.ItemDetailList = new List<ItemDetailViewModel>();
            foreach (int id in itemList.IdList)
            {
                string cartID = Session["cartID"] != null ? Convert.ToString(Session["cartID"]) : null;
                ItemDetailViewModel itemDetail = new ItemDetailViewModel();
                itemDetail.ItemData = itemService.GetItemByID(id);
                itemDetail.InCart = cartService.checkCartItem(cartID, id);
                itemList.ItemDetailList.Add(itemDetail);
            }
            return View(itemList);
        }

        //商品頁
        public ActionResult Item(int itemID)
        {
            string cartID = Session["cartID"] != null ? Convert.ToString(Session["cartID"]) : null;
            ItemDetailViewModel itemDetail = new ItemDetailViewModel();
            itemDetail.ItemData = itemService.GetItemByID(itemID);
            itemDetail.InCart = cartService.checkCartItem(cartID, itemID);
            return View(itemDetail);
        }

        //public ActionResult ItemBlock(int itemID)

        //新增商品
        [Authorize(Roles ="1")]
        public ActionResult Create()
        {
            return View();
        }

        //新增商品
        [HttpPost]
        [Authorize(Roles = "1")]
        public ActionResult Create(ItemCreateViewModel data)
        {
            if (data.ItemImage != null)
            {
                string fileName = Path.GetFileName(data.ItemImage.FileName);
                string fileUrl = Path.Combine(Server.MapPath("~/Upload/"), fileName);
                data.ItemImage.SaveAs(fileUrl);
                data.ItemData.Image = fileName;
                itemService.AddItem(data.ItemData);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ItemImage", "請選擇上傳檔案");
                return View(data);
            }
        }

        //刪除商品
        [Authorize(Roles ="1")]
        public ActionResult Remove(int itemID)
        {
            itemService.RemoveItem(itemID);
            return RedirectToAction("Index");
        }
    }
}