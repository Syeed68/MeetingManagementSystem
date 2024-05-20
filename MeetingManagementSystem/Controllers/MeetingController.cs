using MeetingManagementSystem.Models;
using MeetingManagementSystem.Models.Entities;
using MeetingManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Create(VMmeetingMinutesMaster MeetingMinutesMaster)
        {
            await _db.AddAsync(new MeetingMinutesMaster
            {
                CustomerId= MeetingMinutesMaster.CustomerId,
                Date=MeetingMinutesMaster.Date,
                Time = MeetingMinutesMaster.Time,
                MeetingPlace= MeetingMinutesMaster.MeetingPlace,
                AttendsFromClientSide = MeetingMinutesMaster.AttendsFromClientSide,
                AttendsFromHostSide= MeetingMinutesMaster.AttendsFromHostSide,
                MeetingAgenda = MeetingMinutesMaster.MeetingAgenda,
                MeetingDiscussion = MeetingMinutesMaster.MeetingDiscussion,
                MeetingDecision = MeetingMinutesMaster.MeetingDecision
            });
            return Json("Success");
        }
    }
}
