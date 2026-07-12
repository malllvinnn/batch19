using NUnit.Framework;

[TestFixture]
public class PaymentService_IsTest
{
  [Test]
  public void ProcessPayment_False_WhenZero_AfterFix()
  {
    var processor = new Mock<ITransactionProcessor>();
    var service = new PaymentService(processor.Object);

    // Re-run the exact repro of the original bug
    var result = service.ProcessPayment(new Payment { Amount = 0 });
    Assert.That(result, Is.False);

    // Regression: valid cases must still work
    var ok = service.ProcessPayment(new Payment { Amount = 100 });
    Assert.That(ok, Is.True);
  }
}