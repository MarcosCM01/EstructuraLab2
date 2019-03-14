﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetaLabUnidad3.Models;
using BetaLabUnidad3.Singleton;

namespace BetaLabUnidad3.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Index()
        {
            return View(DataAlmacenada.Instancia.ListaPedidos);
        }

        // GET: Pedidos/CrearPedido
        public ActionResult CrearPedido()
        {
            return View();
        }

        // POST: Pedidos/CrearPedido
        [HttpPost]
        public ActionResult CrearPedido(FormCollection collection, Pedidos pedido)
        {   
            try
            {

                if(string.IsNullOrEmpty(pedido.ClientName) || string.IsNullOrEmpty(pedido.direccion) || string.IsNullOrEmpty(pedido.nit))
                {
                    ViewBag.Error = "Campos obligatorios";
                    return View(pedido);
                }
                else
                {
                    //DataAlmacenada.Instancia.ListaPedidos.Add(pedido);
                    TempData["ClientName"] = pedido.ClientName;
                    TempData["direccion"] = pedido.direccion;
                    TempData["nit"] = pedido.nit;
                    return RedirectToAction("AgregarMed");
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/AgregarMed
        public ActionResult AgregarMed(string ClientName)//
        {
            foreach (var item in DataAlmacenada.Instancia.ListaMed)
            {
                if (item.Nombre == ClientName)
                {
                    item.existencia--;
                   
                    Pedidos pedidoAgregado = new Pedidos();
                    pedidoAgregado.nit = Convert.ToString(TempData["nit"]);
                    pedidoAgregado.ClientName = Convert.ToString(TempData["ClientName"]);
                    pedidoAgregado.direccion = Convert.ToString(TempData["direccion"]);

                    pedidoAgregado.ListaMedPedido = item.Nombre + "\n";
                    pedidoAgregado.total += item.precio;

                    DataAlmacenada.Instancia.ListaPedidos.Add(pedidoAgregado);
                }
                else
                {
                    ViewBag.Error = "No hay cantidad necesaria.";
                    //return View(DataAlmacenada.Instancia.ListaMed);
                }
            }
            return View(DataAlmacenada.Instancia.ListaMed);
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult AgregarMed(string ClientName, FormCollection collection, Pedidos pedido)
        {
            try
            {
               //foreach(var item in DataAlmacenada.Instancia.ListaMed)
               // {
               //     item.pedido = int.Parse(collection["MedAgregado"]);
               // }

               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
