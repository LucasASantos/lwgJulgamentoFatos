using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Enums;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LDSI.Lwg.Apresentacao.Areas.Identity.Pages.Account
{
  [AllowAnonymous]
  public class RegisterModel : PageModel
  {
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ICursoRepository _cursoRepository;

    public RegisterModel(
      SignInManager<ApplicationUser> signInManager,
      UserManager<ApplicationUser> userManager,
      ILogger<RegisterModel> logger,
      IEmailSender emailSender,
      ICursoRepository cursoRepository)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _logger = logger;
      _emailSender = emailSender;
      _cursoRepository = cursoRepository;
    }



    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public List<Curso> Cursos => _cursoRepository.GetAll().ToList();

    public class InputModel
    {
      [Required]
      [Display(Name = "Nome")]
      public string Nome { get; set; }

      [Required]
      [Display(Name = "Login")]
      public string Login { get; set; }

      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }

      [Required]
      [StringLength(100)]
      [DataType(DataType.Password)]
      [Display(Name = "Senha")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirmar senha")]
      [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
      public string ConfirmPassword { get; set; }

      [Required]
      public bool EhAluno { get; set; } = false;

      [Required]
      public Guid CursoId { get; set; }

    }

    public void OnGet(string returnUrl = null)
    {
      ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
      returnUrl = returnUrl ?? Url.Content("~/");
      if (ModelState.IsValid)
      {
        var user = new ApplicationUser
        {
          UserName = Input.Login,
          Email = Input.Email,
          Nome = Input.Nome,
        };

        if (Input.EhAluno)
        {
          user.CursoId = Input.CursoId;
          user.TipoUsuario = TipoUsuario.Aluno;
        }
        else
        {
          user.TipoUsuario = TipoUsuario.Professor;
        }

        var result = await _userManager.CreateAsync(user, Input.Password);


        if (result.Succeeded)
        {
          _logger.LogInformation("User created a new account with password.");

          var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          var callbackUrl = Url.Page(
              "/Account/ConfirmEmail",
              pageHandler: null,
              values: new { userId = user.Id, code = code },
              protocol: Request.Scheme);

          await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
              $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

          var tipoUsuario = Input.EhAluno ? TipoUsuario.Aluno.ToString() : TipoUsuario.Professor.ToString();
          await _userManager.AddClaimAsync(user, new Claim(tipoUsuario, tipoUsuario));

          await _signInManager.SignInAsync(user, isPersistent: false);
          return LocalRedirect(returnUrl);
        }
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      // If we got this far, something failed, redisplay form
      return Page();
    }
  }
}
