﻿using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Encrypt;
using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAspNetRolesBusiness rolesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IAspNetUsersBusiness usersBusiness;
        public AccountController(IAspNetRolesBusiness _rolesBusiness, IAspNetUsersBusiness _usersBusiness)
        {
            rolesBusiness = _rolesBusiness;
            usersBusiness = _usersBusiness;
        }


        // GET: Account
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdRol = new SelectList(rolesBusiness.GetRoles(), "Id", "Name");
                return View();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "UserName,PasswordHash")]AspNetUsersVM usersVM,string IdRol)
        {
            try
            {
                AspNetUsersDomainModel usersDomainModel = new AspNetUsersDomainModel();
                AutoMapper.Mapper.Map(usersVM, usersDomainModel);
                AspNetRolesDomainModel rolesDomainModel = new AspNetRolesDomainModel();
                usersDomainModel.Id = Guid.NewGuid().ToString();
                usersDomainModel.PasswordHash=Funciones.Encrypt(usersDomainModel.PasswordHash);
                rolesDomainModel.Id = IdRol;
                usersDomainModel.AspNetRolesDomainModel = rolesDomainModel;
                if (usersBusiness.AddUpdateUser(usersDomainModel))
                {
                    ViewBag.IdRol = new SelectList(rolesBusiness.GetRoles(), "Id", "Name");
                    return View();
                }
                else {
                    Log.Error("Ocurrio una exepcion al intentar guardar el usuario");
                    loggerdb.Error("Error en la insercion del usuario");
                    return RedirectToAction("InternalServerError", "Error");
                }
            }
            catch (System.Exception ex)
            {

                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetUsuarios()
        {
            try
            {
                var usuariosVM = new List<AspNetUsersVM>();
                var usuariosDM = usersBusiness.GetUsers();
                AutoMapper.Mapper.Map(usuariosDM,usuariosVM);
                return Json(usuariosVM, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return Json(Recursos.Recursos_Sistema.ERROR_LOAD_FILE_JSON,JsonRequestBehavior.AllowGet);
            }
        }

    }
}