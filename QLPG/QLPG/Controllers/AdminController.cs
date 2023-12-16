using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPG.Models;
using QLPG.ViewModel;

namespace QLPG.Controllers
{
    public class AdminController : Controller
    {
        private QLPG1Entities db = new QLPG1Entities();
        public ActionResult Index()
        {
            MultipleData data = new MultipleData();

            // Lấy toàn bộ dữ liệu
            data.hoiViens = db.HoiVien.Include("ThanhVien").ToList();
            data.vien = db.ThanhVien.ToList();
            data.chiTietDK_ = db.ChiTietDK_GoiTap.ToList();

            //// Lấy số thông báo mới từ TempData
            //int newNotificationCount = (int)(TempData["NewNotificationCount"] ?? 0);

            //// Truyền số thông báo mới cho view
            //ViewBag.NewNotificationCount = newNotificationCount;

            //// Lấy thông báo đăng ký từ TempData hoặc Session
            //string registrationNotification = "";

            //if (User.Identity.IsAuthenticated)
            //{
            //    var currentUser = db.Account.SingleOrDefault(u => u.Username == User.Identity.Name);

            //    if (currentUser != null)
            //    {
            //        registrationNotification = (string)(Session[$"{currentUser.Username}_RegistrationNotification"] ?? "");
            //        Session[$"{currentUser.Username}_RegistrationNotification"] = null; // Đánh dấu là đã đọc
            //    }
            //}
            //else
            //{
            //    registrationNotification = (string)TempData["RegistrationNotification"];
            //}

            //// Thêm thông báo đăng ký vào danh sách trong model
            //if (!string.IsNullOrEmpty(registrationNotification))
            //{
            //    data.RegistrationNotifications.Add(registrationNotification);
            //    // Tăng biến đếm thông báo mới
            //    data.NewNotificationCount++;
            //}

            //// Truyền thông báo đăng ký cho view
            //ViewBag.RegistrationNotification = registrationNotification;

            // Tính số lượng hội viên mới
            DateTime today = DateTime.Now.Date;
            int newMembersCount = data.hoiViens.Count(hv => hv.NgayGiaNhap.HasValue && hv.NgayGiaNhap.Value.Date == today);

            // Truyền số lượng hội viên mới cho view
            ViewBag.NewMembersCount = newMembersCount;

            return View(data);
        }


        //// Trong phương thức xử lý thông báo đăng ký tập thử
        //[HttpPost]
        //public ActionResult Register(string tenTV)
        //{
        //    // Xử lý đăng ký

        //    // Tạo thông báo đăng ký và thêm vào danh sách trong ViewBag
        //    string registrationNotification = $"Đăng ký thành công cho {tenTV} vào ngày {DateTime.Now}.";
        //    ViewBag.RegistrationNotifications.Add(registrationNotification);

        //    // Tăng biến đếm thông báo mới
        //    ViewBag.NewNotificationCount++;

        //    // Lưu thông báo vào TempData cho hiển thị trên view
        //    TempData["AdminNotification"] = registrationNotification;

        //    // Redirect hoặc trả về view tương ứng
        //    return RedirectToAction("Index");
        //}


    }
}
