using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace CadastroLivroAPI.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CadastroLivroController : ControllerBase
    {
        private readonly DataContext _context;

        public CadastroLivroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CadastroLivro>>> Get()
        {
            return Ok(await _context.CadastroLivros.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroLivro>> Get(int id)
        {
            var book = await _context.CadastroLivros.FindAsync(id);
            if (book == null)
            {
                return BadRequest("Book not found!");
            }
            return Ok(await _context.CadastroLivros.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<CadastroLivro>>> AddBook(CadastroLivro book)
        {
            _context.CadastroLivros.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.CadastroLivros.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<CadastroLivro>>> UpdateBook(CadastroLivro request)
        {
            var dbBook = await _context.CadastroLivros.FindAsync(request.Id);
            if (dbBook == null)
                return BadRequest("Book not found!");

            dbBook.Name = request.Name;
            dbBook.Author = request.Author;
            dbBook.Company = request.Company;
            dbBook.Year = request.Year;

            await _context.SaveChangesAsync();

            return Ok(await _context.CadastroLivros.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CadastroLivro>>> Delete(int id)
        {
            var dbBook = await _context.CadastroLivros.FindAsync(id);
            if (dbBook == null)
                return BadRequest("Book not found!");

            _context.CadastroLivros.Remove(dbBook);
            await _context.SaveChangesAsync();

            return Ok(await _context.CadastroLivros.ToListAsync());
        }
    }
}
