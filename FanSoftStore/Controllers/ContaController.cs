using FanSoftStore.UI.Data;
using FanSoftStore.UI.Infra;
using FanSoftStore.UI.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
            return View(new UsuarioViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _dataContect.Usuarios.FirstOrDefault(x => x.Email.ToLower().Equals(usuarioViewModel.Email.ToLower()));

            //VERIFICA SE ENCONTROU
            if (usuario != null)
            {
                if (usuario.Senha.Equals(usuarioViewModel.Senha.Encrypt()))
                {
                    if (ModelState.IsValid)
                    {
                        //AUTENTICAR O USUARIO
                        //USANDO CLAINS
                        //o clains usa o clains identity
                        //E USAMOS TAMBEM O IPRINCIPAL

                        //aqui é para a autentica~çao
                        var identity = new ClaimsIdentity(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                ClaimTypes.Name,
                                ClaimTypes.Role);


                        //AGORA PARA A AUTORIZAÇÃO
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Email));
                        identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));

                        //ADICIONAMOS AS REGRAS AO PRINCIPAL
                        var principal = new ClaimsPrincipal(identity);

                        //aqui geramos o cookie
                        await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                principal,
                                new AuthenticationProperties()
                                {
                                    IsPersistent = usuarioViewModel.Lembrar
                                }
                            );

                        //VERIFICA SE EXISTE ALGUMA PAHINA PARA DIRECIONAR O USUARIO
                        // E VERIFICA SE CLIENTE ESTA NAVEGANDO DENTRO DO SEU DOMINIO
                        if (!string.IsNullOrEmpty(usuarioViewModel.ReturnUrl) && Url.IsLocalUrl(usuarioViewModel.ReturnUrl))
                        {
                            return Redirect(usuarioViewModel.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Produtos");
                        }
                        
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Conta");
        }
    }
}