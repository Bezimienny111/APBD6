using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Model.Dto;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase {
        private readonly IDbService _service;

        public DoctorController(IDbService Dbservice)
        {
            _service = Dbservice;
        }

        [HttpGet]
        public IEnumerable<Doctor> GetDoctor() {     
            return _service.GetDoctor();
        }
        [Route("api/prescripions")]
        [HttpPost]
        public Prescription GetPrescription(PrescriptionRequest req)
        {
            return _service.GetPrescription(req);
        }


        [Route("api/doctors/Insert")]
        [HttpPost]
        public IActionResult InsertDoctor(DoctorRequest req) {
            try {
                _service.InsertDoctor(req);
                return StatusCode(201, req);
            }
            catch (MyException e) {
                return StatusCode(e.i, e.Message);
            }
        }
        [Route("api/doctors/delete")]
        [HttpPost]
        public IActionResult Delete(DoctorRequestId req) {
            try {
                _service.Delete(req);
                return StatusCode(201, "Deleted");
            }catch (MyException e) {
                return StatusCode(e.i, e.Message);
            }
        }
        [Route("api/doctors/update")]
        [HttpPost]
        public IActionResult Update(DoctorRequest req) {
            try {
                _service.Update(req);
            return StatusCode(201, "Updated");
            }catch (MyException e){
                return StatusCode(e.i, e.Message);
            }
        }




    }
}
