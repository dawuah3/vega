using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Core.Models;
using vega.Core;
using vega.Persistence;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        [HttpGet("/api/vehicles/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await _context
                .Makes
                .Include(m => m.Models)
                .ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}