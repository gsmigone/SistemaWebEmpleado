using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;

        public EmpleadoController(EmpleadoContext context) { _context = context; }

        // GET: /empleado
        public IActionResult Index()
        {
            return View(_context.Empleados.ToList());
        }

        [HttpGet]
        //GET: /empleado/create
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (empleado != null)
            {
                _context.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", empleado);

        }

        [HttpGet]
        [ActionName("ListarPorTitulo")]
        public IActionResult ListarPorTitulo(string titulo)
        {
            IEnumerable<Empleado> listTitulo = BuscarPorTitulo(titulo);
            return View("Index", listTitulo);

        }

        [NonAction]
        public IEnumerable<Empleado> BuscarPorTitulo(string titulo)
        {
            if (titulo != null)
            {
                IEnumerable<Empleado> ListEmpleados = (from e in _context.Empleados
                                                       where e.Titulo.ToLower() == titulo.ToLower()
                                                       select e).ToList();
                return ListEmpleados;
            }
            else
                return Enumerable.Empty<Empleado>();
        }

        [HttpGet]
        [ActionName("TraerUno")]
        //GET: /empleado/traeruno/id
        public IActionResult TraerUno(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Traeruno", empleado);
        }



        //GET: empleado/delete/id

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();

            }
            return View("Delete", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]

        //POST: /empleado/DeleteConfirmed/id

        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //GET: empleado/editar
        [HttpGet]
        [ActionName("Editar")]
        public IActionResult Editar(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null) return NotFound();
            return View("Editar", empleado);
        }

        //POST: empleado/editar
        [HttpPost]
        public IActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Editar");

        }


    }


}
