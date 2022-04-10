using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : Controller
    {
        private readonly AppDbContext _context;

        public EquipamentoController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Equipamento.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetEquipamento")]
        public IActionResult Get(int id)
        {
            try
            {
                var equipamentoTemp = _context.Equipamento.Where(c => c.Id == id).FirstOrDefault();
                if(equipamentoTemp == null)
                    return NotFound();
                else
                    return Ok(equipamentoTemp);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Equipamento equipamento)
        {
            try
            {
                _context.Equipamento.Add(equipamento);
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Equipamento equipamento)
        {
            try
            {
                if(equipamento.Id == id)
                {
                    _context.Entry(equipamento).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetEquipamento", new { id = equipamento.Id }, equipamento);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var equipamentoTemp = _context.Equipamento.Where(c => c.Id == id).FirstOrDefault();

                if(equipamentoTemp == null)
                    return NotFound();
                else
                {
                    _context.Remove(equipamentoTemp);
                    _context.SaveChanges();
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
