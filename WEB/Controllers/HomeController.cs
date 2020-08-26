using WEB.Filters;
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
using LogicLayer.Exceptions;
using WEB.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Ninject.Activation;

namespace WEB.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        IRecordService service;

        public HomeController(IRecordService service)
        {
            this.service = service;
        }

        [HttpGet]
        public RecordViewModel Get()
        {
            RecordViewModel model = new RecordViewModel();
            model.Records = service.GetRecords();

            return model;
        }

        // POST
        [HttpPost]
        public ActionResult Post(RecordDTO record)
        {
            record.Id = service.AddRecord(record);
            return Ok(record);
        }

        // PUT
        [HttpPut]
        [AddCookieWithId]
        public ActionResult Put([CustomizeValidator(RuleSet = "*")] RecordDTO record)
        {
            try
            {
                service.ChangeRecord(record);
                return Ok(record);
            }
            catch (RecordNotFoundException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}
