using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class AccountBase
    {
        public static AccountBase CreateAccount(AccountType type)
        {
            //AccountBase account = null;
            //switch (type)
            //{
            //    case AccountType.Silver:
            //        account = new SilverAccount();
            //        break;
            //    case AccountType.Gold:
            //        account = new GoldAccount();
            //        break;
            //    case AccountType.Platinum:
            //        account = new PlatinumAccount();
            //        break;
            //}
            //return account;
            return type switch
            {
                AccountType.Silver => new SilverAccount(),
                AccountType.Gold => new GoldAccount(),
                AccountType.Platinum => new PlatinumAccount(),
                _ => throw new ArgumentException("Invalid account type")
            };

        }
        public void Deposit(decimal amount)
        {

            if (amount > 0)
            {
                RewardPoints += CalculateRewardPoints(amount);
                Balance += amount;
            }
            else
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

        }


        public decimal Balance
        {
            get;
            protected set;
        }

        public int RewardPoints
        {
            get;
            protected set;
        }

        public void AddTransaction(decimal amount)
        {
            if (amount > 0)
            {
                RewardPoints += CalculateRewardPoints(amount);
                //RewardPoints += (int)(amount / 1000) * 200;
            }
            Balance += amount;
        }

        public abstract int CalculateRewardPoints(decimal amount);

        public abstract void Withdraw(decimal amount);
    }
}

