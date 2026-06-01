using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Data;

[Route("api/[controller]")]
[ApiController]
public class PurchasesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PurchasesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Purchase
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchase()
    {
        // Quem é o utilizador que se encontra autenticado?
        var correntUser = User.Identity!.Name!;


        // Obter as compras do utilizador autenticado
        var purchases = await _context.Purchases
            .Include(p => p.Buyer)
            .Where(p => p.Buyer.UserName == correntUser)
            .Include(p => p.ListOfPhotos)
            .ToListAsync();
        return purchases;
    }

    // GET: api/Purchase/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Purchase>> GetPurchase(int id)
    {
        var purchase = await _context.Purchases.FindAsync(id);

        if (purchase == null)
        {
            return NotFound();
        }

        return purchase;
    }

    // PUT: api/Purchase/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPurchase(int? id, Purchase purchase)
    {
        if (id != purchase.Id)
        {
            return BadRequest();
        }

        _context.Entry(purchase).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PurchaseExists(id))
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

    // POST: api/Purchase
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
    }

    // DELETE: api/Purchase/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePurchase(int? id)
    {
        var purchase = await _context.Purchases.FindAsync(id);
        if (purchase == null)
        {
            return NotFound();
        }

        _context.Purchases.Remove(purchase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PurchaseExists(int? id)
    {
        return _context.Purchases.Any(e => e.Id == id);
    }
}
