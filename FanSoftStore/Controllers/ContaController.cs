using FanSoftStore.UI.Data;
using FanSoftStore.UI.Infra;
using FanSoftStore.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FanSoftStore.UI.Controllers
{
    public class ContaController : Controller
    {
        private readonly DataContext _dataContect;

        public ContaController(DataContext dataContect)
        {
            _dataContect = dataContect;
        }



        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _dataContect.Usuarios.FirstOrDefault(x => x.Email.ToLower().Equals(usuarioViewModel.ToString().ToLower()));

            //VERIFICA SE ENCONTROU
            if (usuario != null)
            {
                if (usuario.Senha.Equals(usuarioViewModel.Senha.Encrypt()))
                {
                    if (ModelState.IsValid)
                    {
                        //AUTENTICAR O USUARIO
                        //USANDO CLAINS

                    }
                }
                else
                {
                    ModelState.AddModelError("Senha", "Senha inválida");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Não localizado");
            }
            
            return View(usuarioViewModel);
        }
    }
}