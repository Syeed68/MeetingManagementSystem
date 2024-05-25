using MeetingManagementSystem.Models;
using MeetingManagementSystem.Models.Entities;
using MeetingManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MeetingManagementSystem.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MeetingController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(VMmeetingMinutesMaster vm)
        {
            ;
            string ReturnSTR = "";
            var resultParameter = new SqlParameter("@ReturnMSG", SqlDbType.VarChar, 300)
            {
                Direction = ParameterDirection.Output
            };
            try
            {
                DateTime time;
                DateTime.TryParse(vm.Time, out time);
                _db.Database.ExecuteSqlRaw("Meeting_Minutes_Master_Tbl @CustomerId, @Date, @Time, @MeetingPlace, @AttendsFromClientSide, @AttendsFromHostSide, @MeetingAgenda, @MeetingDiscussion, @MeetingDecision, @ReturnMSG out",
               new SqlParameter("@CustomerId", vm.CustomerId),
               new SqlParameter("@Date", vm.Date),
               new SqlParameter("@Time", time),
               new SqlParameter("@MeetingPlace", vm.MeetingPlace),
               new SqlParameter("@AttendsFromClientSide", vm.AttendsFromClientSide),
               new SqlParameter("@AttendsFromHostSide", vm.AttendsFromHostSide),
               new SqlParameter("@MeetingAgenda", vm.MeetingAgenda),
               new SqlParameter("@MeetingDiscussion", vm.MeetingDiscussion),
               new SqlParameter("@MeetingDecision", vm.MeetingDecision),
               resultParameter);
               ReturnSTR = (string)resultParameter.Value;

                if(ReturnSTR!= "Failed")
                {
                    foreach(var i in vm.Products)
                    {
                        _db.Database.ExecuteSqlRaw("SPMeetingMinutesDetails @MeetingMinutesMasterId,@ProductId, @Quantity",
                        new SqlParameter("@MeetingMinutesMasterId", Convert.ToInt32(ReturnSTR)),
                        new SqlParameter("@ProductId", i.ProductId),
                        new SqlParameter("@Quantity", i.Quantity));
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           

            


            return Json("Success");
        }
    }
}
