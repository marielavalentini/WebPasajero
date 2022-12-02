using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebPasajero.Data;
using WebPasajero.Models;

namespace WebPasajero.Controllers
{
    public class PasajeroController : Controller
    {
        //inyeccion de dependencia

        private readonly PasajeroContext _context;

        public PasajeroController(PasajeroContext context)
        {
            _context = context;
        }

        //GET: /pasajero

        public IActionResult Index()
        {
            return View("Index", _context.Pasajeros.ToList());
        }

        [HttpGet("/pasajero/ListaPorFechaNacimiento/{FechaNacimiento}")]
        // GET: 
        public IActionResult ListaPorFechaNacimiento(DateTime dob)
        {
            List<Pasajero> lista = (from p in _context.Pasajeros
                                    where p.FechaNacimiento == dob
                                    select p).ToList();
            return View("Index", lista);
        }

        [HttpGet("/pasajero/ListaPorCiudad/{Ciudad}")]
        // GET: 
        public IActionResult ListaPorCiudad(string ciudad)
        {
            List<Pasajero> lista = (from p in _context.Pasajeros
                                    where p.Ciudad == ciudad
                                    select p).ToList();
            return View("Index", lista);
        }

        public ActionResult Create()
        {
            Pasajero pasajero = new Pasajero();
            return View("Create", pasajero);

        }

        [HttpPost]

        public ActionResult Create(Pasajero pasajero)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pasajero);
            }
            else
            {
                _context.Pasajeros.Add(pasajero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

