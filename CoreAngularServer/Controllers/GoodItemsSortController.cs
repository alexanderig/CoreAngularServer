using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAngularServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAngularServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodItemsSortController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public GoodItemsSortController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/GoodItems
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GoodItem>>> GetGoodItemsSort(int id)
        {
            var goods = await _context.GoodItems
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

                }).ToListAsync();
            goods.Reverse();
            return goods.Take(id).ToList();
        }

    }
}
