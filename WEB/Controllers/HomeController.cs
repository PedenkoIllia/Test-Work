using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogicLayer.DataTransferObjects;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        IRecordService service;

        public HomeController(IRecordService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<RecordViewModel> Get()
        {
            IEnumerable<RecordDTO> list = service.GetRecords();

            var mapper = new MapperConfiguration(config => config.CreateMap<RecordDTO, RecordViewModel>()).CreateMapper();
            IEnumerable<RecordViewModel> result = mapper.Map<IEnumerable<RecordDTO>, List<RecordViewModel>>(list);

            return result;
        }

        // POST: api/Home
        [HttpPost]
        public ActionResult Post([FromBody] RecordViewModel record)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction("Get");
            }

            service.AddRecord(new RecordDTO { Code = record.Code, Name = record.Name });

            return Ok();
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
