public interface ITransactionProcessor
{
  public bool Process(Payment payment)
  {
    return true;
  }
}