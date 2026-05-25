using API.Data;
using API.Models;
using API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Referencia à base de dados
    /// </summary>
    /// <remarks>Used to query and persist entities via Entity Framework Core.</remarks>
    // Referencia à base de dados
    private readonly ApplicationDbContext _context;
    // Referencia ao UserManager do Identity para gerir os utilizadores
    private readonly UserManager<IdentityUser> _userManager;
    // Referencia ao SignInManager do Identity para gerir o processo de autenticação
    private readonly SignInManager<IdentityUser> _signInManager;
    // Referencia à configuração da aplicação para aceder às definições do JWT
    private readonly IConfiguration _config;

    // construtor do controller
    public AuthController(ApplicationDbContext context, 
                          UserManager<IdentityUser> userManager, 
                          SignInManager<IdentityUser> signInManager, 
                          IConfiguration config)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO login) {

        var user = await _userManager.FindByEmailAsync(login.Username);
        if (user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        if (!result.Succeeded) return Unauthorized();

        var token = GenerateJwtToken(login.Username);

        return Ok(new { token });
    }


    /// <summary>
    /// Cria um token JWT para um utilizador autenticado.
    /// O token inclui a claim "name" com o nome de utilizador e tem uma validade de 2 horas.
    /// O token é assinado usando a chave secreta definida na configuração da aplicação.
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    private string GenerateJwtToken(string username) {
        var claims = new[] {
         new Claim(ClaimTypes.Name, username)
     };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}