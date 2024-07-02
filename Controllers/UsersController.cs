using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultitrabajosSecurity.DTOs;
using MultitrabajosSecurity.Services;

namespace MultitrabajosSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceUsers _serviceUser;
        public UsersController(IServiceUsers serviceUsers)
        {
            _serviceUser = serviceUsers;
        }

        [HttpGet]
        public async Task<ActionResult>Get()
        {

            var result = await _serviceUser.getAll();

            return Ok(new
            {
                result = result,
                message = result != null ? "OK" : "No se pudo encontrar el Usuario"
            });
        }
        [HttpGet]
        public async Task<ActionResult>Get (int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var result = await _serviceUser.getUserById(id);

            return Ok(new
            {
                result = result,
                message = result !=null ? "OK":"No se pudo encontrar el Usuario"
            });
        }

        [HttpPost]
        public async Task<ActionResult> Save(UserRequest user)
        {
            Models.User userData = new Models.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                Password  = user.Password,
                Phone = user.Phone,
                RolId = user.RolId,
                
            };
            var resultSave = await _serviceUser.save(userData);

            return Ok(new
            {
                result = resultSave,
                message = resultSave == true ? "Guardar Correctamente":"Error al Guardar" //Operador Terneraio 
            });
           
        }
        [HttpPost]
        public async Task<ActionResult> Update(UserRequest user)
        {
            Models.User userData = new Models.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                Password = user.Password,
                Phone = user.Phone,
                RolId = user.RolId,

            };
            var resultUpdate = await _serviceUser.update(userData);

            return Ok(new
            {
                result = resultUpdate,
                message = resultUpdate == true ? "Modificado Correctamente" : "Error al Modificar" //Operador Terneraio 
            });

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            
            var resultDelete = await _serviceUser.delete(id);

            return Ok(new
            {
                result = resultDelete,
                message = resultDelete == true ? "Eliminado Correctamente" : "Error al Elimiar" //Operador Terneraio 
            });

        }
    }
}
