using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CamYottoAPI.Models;
using CamYottoAPI.Attributes;

namespace CamYottoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UsuariosController : ControllerBase
    {
        private Tools.Crypto MyCrypto { get; set; }

        private readonly CamYottoDBContext _context;

        public UsuariosController(CamYottoDBContext context)
        {
            _context = context;
            MyCrypto = new Tools.Crypto();
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        //GET
        [HttpGet("ValidateUserLogin")]
        public async Task<ActionResult<Usuario>> ValidateUserLogin(string pEmail, string pPassword)
        {
            //SE VALIDA EL USUARIO POR EL EMAIL Y EL PASSWORD ENCRIPTADO A NIVEL DE API
            string ApiLevelEncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);

            //TAREA: HACER ESTA MISMA CONSULTA PERO USANDO LINQ

            var user = await _context.Usuarios.SingleOrDefaultAsync(e => e.Email == pEmail
                                                                   && e.Contrasenna == ApiLevelEncriptedPassword);

            //SI NO HAY RESPUESTA EN LA CONSULTA SE DEVUELVE EL MENSAJE HTTP NOT FOUND
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Idusuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Idusuario }, usuario);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUser(Usuario user)
        {
            //EL PASSWORD YA VEINE ENCRIPTADO DESDE LA APP, POR UN ASUNTO DE SEGURIDAD (SI ALGUIEN INTERCEPTA EL 
            //REQUEST NO VA A PODER ENTENDER QUE PASSWORD DIGITÓ EL USUARIO)
            //ADEMAS DE ESA ENCRIPTACION ACÁ SE VOLVERA A ENCRIPTAR CON OTRA LLAVE PARA QUE AUNQUE SE PUEDA
            //COPIAR EL PASSWORD (A NIVEL DE APP) NO SE PUEDA USAR CONTRA LA BASE DE DATOS

            string ApiLevelEncriptedPassword = MyCrypto.EncriptarEnUnSentido(user.Contrasenna);

            user.Contrasenna = ApiLevelEncriptedPassword;

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Idusuario }, user);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Idusuario == id);
        }
    }
}
