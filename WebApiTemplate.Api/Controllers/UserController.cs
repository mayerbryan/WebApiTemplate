using Microsoft.AspNetCore.Mvc;
using WebApiTemplate.Api.Data;
using WebApiTemplate.Api.Models;

namespace WebApiTemplate.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {


        //here we define which address we will use for our requisition
        //Post is to send the information to our database (create) 
        //v1 is versioning pattern so if you want to make an update you can copy/paste and change the version to v2
        //after a time you can delete v1 without compromise your api functionality
        [HttpPost("/v1/user")]

        //we use IactionResult here to handle the user input erros like invalid request our other erros
        //instead of making this ourselfs we use the AspNetCore.MVC package to handle this for us
        public IActionResult Post(

            //here we specify from where the app should receive the information to pass to our database
            [FromBody] UserModel User,

            //and where he need to uses this information
            [FromServices] AppDbContext context)
        {
            context.User.Add(User);
            context.SaveChanges();
            return Created("/{User.Id}", User);
        }


        [HttpGet("/v1/user")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.User.ToList());


        [HttpPut("/v1/user/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] UserModel User,
            [FromServices] AppDbContext context)
        {

            var model = context.User.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.FirstName = User.FirstName;
            model.LastName = User.LastName;
            model.Phone = User.Phone;
            model.Email = User.Email;

            context.User.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/v1/user/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {

            var model = context.User.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            context.User.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
