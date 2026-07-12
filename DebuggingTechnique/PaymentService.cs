using System.Diagnostics;

public class PaymentService
{
  // Dependency on an interface
  private ITransactionProcessor _processor;

  public PaymentService(ITransactionProcessor processor)
  {
    _processor = processor;
  }

  public bool ProcessPayment(Payment payment)
  {
    // Quick observation while debugging
    Debug.WriteLine($"Processing payment of {payment.Amount}.");

    if (payment.Amount <= 0)
    {
      Debug.WriteLine("Invalid amount: must be > 0.");
      return false;
    }
    return _processor.Process(payment);
  }
}