using Microsoft.AspNetCore.Mvc;
using MVC_Challenge.Models.Enums;

namespace MVC_Challenge.Controllers
{
    public class AlertsBoostrapController : Controller
    {
        public void Success(string mensaje)
        {
            //TempData.Clear();
            TempData.Add(TypeAlert.Success, mensaje);
        }
        public void Danger(string mensaje)
        {
            TempData.Clear();
            TempData.Add(TypeAlert.Danger, mensaje);
        }
        public void Warning(string mensaje)
        {
            TempData.Add(TypeAlert.Warning, mensaje);
        }
        public void Info(string mensaje)
        {
            TempData.Add(TypeAlert.Info, mensaje);
        }

    }
}
