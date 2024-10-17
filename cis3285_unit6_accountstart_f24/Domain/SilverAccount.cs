using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class SilverAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            //return (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
            return (int)(amount / 1000) * 100;
        }

        //  private const int SilverTransactionCostPerPoint = 10;
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            //if (Balance >= amount)
            //{
            Balance -= amount;
            //}
           //else
           // {
           //     throw new InvalidOperationException("Insufficient funds.");
           // }
        }
    }
}
