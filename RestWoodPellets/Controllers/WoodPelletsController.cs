using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoodPelletsLib;

namespace RestWoodPellets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WoodPelletsController : Controller
    {
        // Get: api/WoodPellets
        [HttpGet]
        public IEnumerable<WoodPellet> GetAll()
        {
            return WoodPelletManager.GetAll();
        }
        // Get: api/WoodPellets/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var woodPellet = WoodPelletManager.GetById(id);
            if (woodPellet == null)
            {
                return NotFound();// 404
            }
            return Ok(woodPellet);// 200
        }
        // Post: api/WoodPellets
        [HttpPost]
        public IActionResult Add(WoodPellet woodPellet)
        {
            WoodPelletManager.Add(woodPellet);
            return CreatedAtRoute(nameof(GetById), new { id = woodPellet.Id }, woodPellet);
        }
        // Put: api/WoodPellets/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, WoodPellet woodPellet)
        {
            if (id != woodPellet.Id)
            {
                return BadRequest();// 400
            }
            try
            {
                WoodPelletManager.Update(woodPellet);
            }
            catch (System.Exception)
            {
                return NotFound();// 404
            
            }
            return NoContent();// 204
        }
    }
}
