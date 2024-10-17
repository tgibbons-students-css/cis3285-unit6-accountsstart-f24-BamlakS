using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GoldAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            return (int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint));
            //return (int)(amount / 1000) * 200;
        }

        private const int GoldTransactionCostPerPoint = 5;
       private const int GoldBalanceCostPerPoint = 2000;
        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            // Apply specific withdrawal logic for Gold accounts if needed
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
        }
    }
}