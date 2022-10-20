using FinalProjectBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsImageController : ControllerBase
    {

        private static readonly ImageConverter _imageConverter = new ImageConverter();

        private readonly AnimalsContext _context;

        public AnimalsImageController(AnimalsContext context)
        {
            _context = context;
        }

        // GET api/<AnimalsImageController>/5
        [HttpGet("{id}")]
       
            public async Task<ActionResult<AnimalsTable>> GetAnimalsImageTable(int id)
            {
            
                var animalsTable = await _context.AnimalsTable.FindAsync(id);
            if (animalsTable == null || animalsTable.AnimalImage == null)
            {
                return NotFound();
            }
            
            else
            {
                byte[] decodedBytes = Convert.FromBase64String(animalsTable.AnimalImage);

                return File(decodedBytes, "image/png");
            }

            }
        

        
       
    }
}
