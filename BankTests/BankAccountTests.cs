using BankTests;
using BankAccountNS;

// The 'using' statement for Test Tools is in GlobalUsings.cs
// using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests                                                           // Marks this class as containing unit tests
    {
        [TestMethod]                                                                                            // Marks this as a test method                                                       
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Debit_WithNegativeAmount_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -5.0;                                                                          // invalid negative value
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);                   // Assert → Verify the exception contains the right message

                return; 
            }

            Assert.Fail("The expected exception for negative debit was not thrown.");
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage); 
                return;                                                                     // Passes if exception is thrown
            }

            Assert.Fail("The expected exception was not thrown.");                          // If no exception is thrown, the exception fails
        }
    }
}