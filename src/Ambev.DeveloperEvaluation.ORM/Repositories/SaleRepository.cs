using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(s => s.SaleItems).FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.SaleItems)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            var existingSale = await GetByIdAsync(sale.Id, cancellationToken);
            if (existingSale == null)
                throw new InvalidOperationException($"Sale with id {sale.Id} not found.");

            existingSale.CustomerId = sale.CustomerId;
            existingSale.TotalAmount = sale.TotalAmount;
            existingSale.IsCancelled = sale.IsCancelled;
            existingSale.SaleDate = sale.SaleDate;

            _context.Sales.Update(existingSale);
            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }
    }
}
