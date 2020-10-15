using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAngularServer.Models;

namespace CoreAngularServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodItemsController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public GoodItemsController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/GoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodItem>>> GetGoodItems()
        {
            return await _context.GoodItems
                .Include("Pictures")
                .Select( g => new GoodItem 
                {
                
                    ID = g.ID,
                    Name = g.Name,
                    Description = g.Description,
                    Price = g.Price,
                    Date = g.Date,
                    PicURL = g.PicURL,
                    CategoryId = g.CategoryId,
                    Pictures = g.Pictures.Select(p => new Picture
                                {
                                    ID = p.ID,
                                    pathURL = p.pathURL,
                                    GoodItemId = p.GoodItemId
                                })                
                
                }).ToListAsync();
        }

        // GET: api/GoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodItem>> GetGoodItem(int id)
        {
             GoodItem goodItem = await _context.GoodItems
                .Where(i => i.ID == id)
                .Include("Pictures")
                .Select(g => new GoodItem
                {

                    ID = g.ID,
                    Name = g.Name,
                    Description = g.Description,
                    Price = g.Price,
                    Date = g.Date,
                    PicURL = g.PicURL,
                    CategoryId = g.CategoryId,
                    Pictures = g.Pictures.Select(p => new Picture
                    {
                        ID = p.ID,
                        pathURL = p.pathURL,
                        GoodItemId = p.GoodItemId
                    })

                }).FirstOrDefaultAsync();
                
                
          

            if (goodItem == null)
            {
                return NotFound();
            }

            return goodItem;
        }

        // PUT: api/GoodItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoodItem(int id, GoodItem goodItem)
        {
            if (id != goodItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(goodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodItemExists(id))
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

        // POST: api/GoodItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoodItem>> PostGoodItem(GoodItem goodItem)
        {
            goodItem.Date = DateTime.Now;
            _context.GoodItems.Add(goodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoodItem", new { id = goodItem.ID }, goodItem);
        }

        // DELETE: api/GoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoodItem>> DeleteGoodItem(int id)
        {
            var goodItem = await _context.GoodItems.FindAsync(id);
            if (goodItem == null)
            {
                return NotFound();
            }

            _context.GoodItems.Remove(goodItem);
            await _context.SaveChangesAsync();

            return goodItem;
        }

        private bool GoodItemExists(int id)
        {
            return _context.GoodItems.Any(e => e.ID == id);
        }
    }
}
