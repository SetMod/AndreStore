using Discount.GrpcService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discount.GrpcService.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Coupon>> GetAllDiscountsAsync();
        Task<Coupon> GetDiscountAsync(string productName);
        Task<bool> CreateDiscountAsync(Coupon coupon);
        Task<bool> UpdateDiscountAsync(Coupon coupon);
        Task<bool> DeleteDiscountAsync(string productName);
    }
}
