using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 購物網站MVC_Demo.Models;
using 購物網站MVC_Demo.Services;
using 購物網站MVC_Demo.ViewModels;

namespace 購物網站MVC_Demo.Controllers
{
    public class CartController : Controller
    {
        CartDBService _cartDBService = new CartDBService();

        [Authorize]
        public ActionResult Index()
        {
            string cartID = Session["cartID"] != null ? Session["cartID"].ToString() : null;
            CartItemViewModel _cartItemViewModel = new CartItemViewModel();
            bool chkCart = _cartDBService.CheckCart(User.Identity.Name, cartID);
            List<CartItem> cartItemList = _cartDBService.GetCartItems(cartID);
            _cartItemViewModel.DataList = cartItemList;
            _cartItemViewModel.IsCartSave = chkCart;
            return View(_cartItemViewModel);
        }

        //// 保存購物車
        //public ActionResult CartSave()

        ////取消保存購物車
        //public ActionResult CartRemove()

        //購物車移除商品
        [Authorize]
        public ActionResult CartItemRemove(int itemID, string target)
        {
            string cartID = Session["cartID"] != null ? Session["cartID"].ToString() : null;
            string msg = string.Empty;
            _cartDBService.RemovedCartItem(cartID, itemID, out msg);
            ActionResult action;
            switch (target)
            {
                case "Item":
                    action = RedirectToAction("Item", "Item", new { Id = itemID });
                    break;
                case "ItemBlock":
                    action = RedirectToAction("ItemBlock", "Item", new { Id = itemID });
                    break;
                default:
                    action = RedirectToAction("Index");
                    break;
            }
            return action;
        }

        //購物車新增商品
        [Authorize]
        public ActionResult CartItemAdd(int itemID, string target)
        {
            string cartID = Session["cartID"] != null ? Session["cartID"].ToString() : null;
            string msg = string.Empty;
            _cartDBService.AddCartItem(cartID, itemID, out msg);
            ActionResult action;
            switch (target)
            {
                case "Item":
                    action = RedirectToAction("Item", "Item", new { Id = itemID });
                    break;
                case "ItemBlock":
                    action = RedirectToAction("ItemBlock", "Item", new { Id = itemID });
                    break;
                default:
                    action = RedirectToAction("Index");
                    break;
            }
            return action;
        }
    }
}