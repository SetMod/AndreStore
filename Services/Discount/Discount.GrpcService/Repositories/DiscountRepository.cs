using Discount.GrpcService.DBContext;
using Discount.GrpcService.Entities;
using Discount.GrpcService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.GrpcService.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscoutDBContext _context;
        public DiscountRepository(DiscoutDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> GetAllDiscountsAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(e => e.ProductName == productName);
            if (coupon == null)
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            return coupon;
        }

        public async Task<bool> CreateDiscountAsync(Coupon entity)
        {
            if (entity == null)
            {
                return false;
                throw new ArgumentNullException($"{nameof(Coupon)} entity must not be null");
            }
            await _context.Coupons.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDiscountAsync(Coupon entity)
        {
            if (entity == null)
            {
                return false;
                throw new ArgumentNullException($"{nameof(Coupon)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            var entity = await _context.Coupons.FirstOrDefaultAsync(e => e.ProductName == productName);
            if (entity == null)
            {
                return false;
                throw new ArgumentNullException($"{nameof(Coupon)} entity with productName = {productName} does not exist");
            }
            try
            {
                _context.Coupons.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public async void SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
