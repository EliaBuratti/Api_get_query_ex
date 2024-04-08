using Api_get_query_ex.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_get_query_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : ControllerBase
    {
        public static readonly List<AccessoriesDto> accessories = new List<AccessoriesDto>
        {
            new(){Id = 1, Name = "Matita", Category = "Forniture per ufficio", Description = "Questa è una descrizione del prodotto", Price = 15.97,},
            new(){Id = 2, Name = "Temperino", Category = "Forniture per ufficio", Description = "Questa è un'altra descrizione del prodotto", Price = 20.99,},
            new(){Id = 3, Name = "Cacciavite", Category = "Attrezzi", Description = "Questa è una descrizione diversa del prodotto", Price = 18.50,},
            new(){Id = 4, Name = "Martello", Category = "Attrezzi", Description = "Questa è una descrizione unica del prodotto", Price = 22.30,},
            new(){Id = 5, Name = "Righello", Category = "Forniture per ufficio", Description = "Questa è una descrizione interessante del prodotto", Price = 16.75,},
            new(){Id = 6, Name = "Forbici", Category = "Forniture per ufficio", Description = "Questa è una descrizione dettagliata del prodotto", Price = 19.99,},
            new(){Id = 7, Name = "Chiave inglese", Category = "Attrezzi", Description = "Questa è una descrizione breve del prodotto", Price = 21.50,},
            new(){Id = 8, Name = "Trapano", Category = "Attrezzi", Description = "Questa è una descrizione lunga del prodotto", Price = 23.30,},
            new(){Id = 9, Name = "Penna", Category = "Forniture per ufficio", Description = "Questa è una descrizione completa del prodotto", Price = 17.75,},
            new(){Id = 10, Name = "Sega", Category = "Attrezzi", Description = "Questa è una descrizione semplice del prodotto", Price = 20.80,},
            new(){Id = 11, Name = "Gomma", Category = "Forniture per ufficio", Description = "Questa è una descrizione complessa del prodotto", Price = 22.60,},
            new(){Id = 12, Name = "Livella", Category = "Attrezzi", Description = "Questa è una descrizione interessante del prodotto", Price = 18.90,},
            new(){Id = 13, Name = "Evidenziatore", Category = "Forniture per ufficio", Description = "Questa è una descrizione unica del prodotto", Price = 21.70,},
            new(){Id = 14, Name = "Pialla", Category = "Attrezzi", Description = "Questa è una descrizione originale del prodotto", Price = 23.50,},
            new(){Id = 15, Name = "Raccoglitore", Category = "Forniture per ufficio", Description = "Questa è una descrizione innovativa del prodotto", Price = 19.80,},
            new(){Id = 16, Name = "Mola", Category = "Attrezzi", Description = "Questa è una descrizione creativa del prodotto", Price = 22.60,},
            new(){Id = 17, Name = "Post-it", Category = "Forniture per ufficio", Description = "Questa è una descrizione dettagliata del prodotto", Price = 24.40,},
            new(){Id = 18, Name = "Metro", Category = "Attrezzi", Description = "Questa è una descrizione breve del prodotto", Price = 20.70,},
            new(){Id = 19, Name = "Busta", Category = "Forniture per ufficio", Description = "Questa è una descrizione lunga del prodotto", Price = 23.50,},
            new(){Id = 20, Name = "Squadra", Category = "Forniture per ufficio", Description = "Questa è una descrizione completa del prodotto", Price = 25.30,},
            new(){Id = 21, Name = "Compasso", Category = "Forniture per ufficio", Description = "Questa è una descrizione semplice del prodotto", Price = 21.80,},
            new(){Id = 22, Name = "Cutter", Category = "Forniture per ufficio", Description = "Questa è una descrizione complessa del prodotto", Price = 24.60,},
            new(){Id = 23, Name = "Pinza", Category = "Attrezzi", Description = "Questa è una descrizione interessante del prodotto", Price = 20.90,},
            new(){Id = 24, Name = "Cacciavite a stella", Category = "Attrezzi", Description = "Questa è una descrizione unica del prodotto", Price = 23.70,},
            new(){Id = 25, Name = "Cacciavite a taglio", Category = "Attrezzi", Description = "Questa è una descrizione originale del prodotto", Price = 25.50,},
            new(){Id = 26, Name = "Matita copiativa", Category = "Forniture per ufficio", Description = "Questa è una descrizione innovativa del prodotto", Price = 21.80,},
            new(){Id = 27, Name = "Pennarello", Category = "Forniture per ufficio", Description = "Questa è una descrizione creativa del prodotto", Price = 24.60,},
            new(){Id = 28, Name = "Righello flessibile", Category = "Forniture per ufficio", Description = "Questa è una descrizione dettagliata del prodotto", Price = 26.40,},
            new(){Id = 29, Name = "Etichette", Category = "Forniture per ufficio", Description = "Questa è una descrizione breve del prodotto", Price = 22.70,},
            new(){Id = 30, Name = "Chiave a tubo", Category = "Attrezzi", Description = "Questa è una descrizione lunga del prodotto", Price = 25.50,},
        };


        [HttpGet]
        public IActionResult GetAccessories([FromQuery] int page = 1, [FromQuery] int limit = 10, [FromQuery] string orderBy = "Id", [FromQuery] bool orderAsc = true, [FromQuery] string categories = null, [FromQuery] string search = null)
        {
            var result = accessories.AsQueryable();

            if (!string.IsNullOrEmpty(categories))
            {
                result = result.Where(p => p.Category == categories);
            }

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Name.Contains(search));
            }

            result = orderAsc ? result.OrderBy(p => p.GetType().GetProperty(orderBy).GetValue(p)) :
                result.OrderByDescending(p => p.GetType().GetProperty(orderBy).GetValue(p));

            var productPagination = result.Skip((page - 1) * limit).Take(limit);

            return Ok(productPagination);
        }


    }


}
