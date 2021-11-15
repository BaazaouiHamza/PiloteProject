using HazemPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using HazemPFE.Dtos;

namespace HazemPFE.Controllers.Api
{
    public class PilotesController : ApiController
    {
        private ApplicationDbContext _context;
        public PilotesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/Pilotes
        public IHttpActionResult GetPilotes()
        {
            var piloteDto = _context.Pilotes
                .ToList()
                .Select(Mapper.Map<Pilote, PiloteDto>);
            return Ok(piloteDto);
        }
        //GET /api/Pilotes/1
        public IHttpActionResult GetPilote(int id)
        {
            var pilote = _context.Pilotes.SingleOrDefault(m => m.Id == id);
            if (pilote == null)
                NotFound();
            return Ok(Mapper.Map<Pilote, PiloteDto>(pilote));
        }
        //Post /api/Pilotes
        [HttpPost]
        public IHttpActionResult CreatePilote(PiloteDto piloteDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var pilote = Mapper.Map<PiloteDto, Pilote>(piloteDto);
            _context.Pilotes.Add(pilote);
            _context.SaveChanges();
            piloteDto.Id = pilote.Id;
            return Created(new Uri(Request.RequestUri + "/" + pilote.Id), piloteDto);
        }
        //Put /api/Pilotes
        [HttpPut]
        public IHttpActionResult UpdatePilote(int id, PiloteDto piloteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var piloteInDb = _context.Pilotes.SingleOrDefault(m => m.Id == id);

            if (piloteInDb == null)
                return NotFound();

            Mapper.Map(piloteDto, piloteInDb);
            _context.SaveChanges();
            return Ok();
        }
        //Delete /api/Pilotes
        [HttpDelete]
        public IHttpActionResult DeletePilote(int id)
        {
            var piloteInDb = _context.Pilotes.SingleOrDefault(m => m.Id == id);

            if (piloteInDb == null)
                return NotFound();

            _context.Pilotes.Remove(piloteInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
