using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectBackend.Models;
using System.IO;
using System.Drawing;

namespace FinalProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsTablesController : ControllerBase
    {
        private static readonly ImageConverter _imageConverter = new ImageConverter();

        private readonly AnimalsContext _context;

        public AnimalsTablesController(AnimalsContext context)
        {
            _context = context;
        }

       
        // GET: api/AnimalsTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileDownload>>> GetAnimalsTable()
        {
            List<AnimalsTable> animalsTable = _context.AnimalsTable.ToList();
            List<FileDownload> textInfo = new List<FileDownload>();
            textInfo.Clear();
            foreach (AnimalsTable aT in animalsTable)
            {
                FileDownload fD = new FileDownload();
                fD.AnimalId = aT.AnimalId;
                fD.AnimalName = aT.AnimalName;
                fD.AnimalDescription = aT.AnimalDescription;
                fD.AnimalCount = aT.AnimalCount;
                textInfo.Add(fD);
            }
            return textInfo;
            

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FileDownload>> GetAnimalsTable(int id)
        {
            var animalsTable = await _context.AnimalsTable.FindAsync(id);
            if (animalsTable == null)
            {
                return NotFound();
            }
            FileDownload fD = new FileDownload();
            fD.AnimalId = animalsTable.AnimalId;
            fD.AnimalName = animalsTable.AnimalName;
            fD.AnimalDescription = animalsTable.AnimalDescription;
            fD.AnimalCount = animalsTable.AnimalCount;
            

            return fD;

        }

        

        // PUT: api/AnimalsTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalsTable(int id,[FromForm] FileUpload changeFile)
        {
            var animalsTable = await _context.AnimalsTable.FindAsync(id);
            if (id != animalsTable.AnimalId)
            {
                return BadRequest();
            }
            animalsTable.AnimalId = changeFile.AnimalId;
            animalsTable.AnimalName = changeFile.AnimalName;
            animalsTable.AnimalDescription = changeFile.AnimalDescription;
            animalsTable.AnimalCount = changeFile.AnimalCount;
            var ms = new MemoryStream();
            changeFile.AnimalImage.CopyTo(ms);
            byte[] imgBytes = ms.ToArray();
            string encodedImg = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
            animalsTable.AnimalImage = encodedImg;

            _context.Entry(animalsTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalsTableExists(id))
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

        // POST: api/AnimalsTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        
        public async Task<ActionResult<AnimalsTable>> PostAnimalsTable([FromForm]FileUpload animalsTable)
        {
            
            var ms = new MemoryStream();
            animalsTable.AnimalImage.CopyTo(ms);
            byte[] imgBytes = ms.ToArray();
            string encodedImg = Convert.ToBase64String(imgBytes,0,imgBytes.Length);
            AnimalsTable aT = new AnimalsTable();
            aT.AnimalId = animalsTable.AnimalId;
            aT.AnimalName = animalsTable.AnimalName;
            aT.AnimalDescription = animalsTable.AnimalDescription;
            aT.AnimalCount = animalsTable.AnimalCount;
            aT.AnimalImage = encodedImg;
            _context.AnimalsTable.Add(aT);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimalsTableExists(aT.AnimalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnimalsTable", new { id = aT.AnimalId }, aT);
        }

        // DELETE: api/AnimalsTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalsTable>> DeleteAnimalsTable(int id)
        {
            var animalsTable = await _context.AnimalsTable.FindAsync(id);
            if (animalsTable == null)
            {
                return NotFound();
            }

            _context.AnimalsTable.Remove(animalsTable);
            await _context.SaveChangesAsync();

            return animalsTable;
        }

        private bool AnimalsTableExists(int id)
        {
            return _context.AnimalsTable.Any(e => e.AnimalId == id);
        }
    }
}
