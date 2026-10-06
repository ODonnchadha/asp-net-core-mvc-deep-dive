using Globomatics.Infrastructure.Services;

namespace Globomatics.Infrastructure.Interfaces.Services;

public interface IPaymentService
{
    Task<PaymentStatus> GetStatusAsync(Guid orderId);
}