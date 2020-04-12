using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    class TransferTransaction
    {
        private Account _fromAccount, _toAccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        bool _executed, _reversed;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            this._amount = amount;
            this._withdraw = new WithdrawTransaction(_fromAccount, this._amount);
            this._deposit = new DepositTransaction(_toAccount, this._amount);
        }
        public bool Executed { get => this._executed; }
        public bool Reversed { get => this._reversed; }
        public bool Sucess 
        { 
            get
            {
                if (this._withdraw.Success && this._deposit.Success)
                    return true;
                return false;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Transfer {_amount.ToString("C")} from {_fromAccount.Name} to {_toAccount.Name}\n");
            _withdraw.Print();
            _deposit.Print();
        }

        public void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transaction has already been attempted");
            }
            else if (this._fromAccount.Balance < this._amount)
            {
                this._executed = false;
                throw new InvalidOperationException("Insufficient fund!");
            }
            else if (this._executed == false && this._fromAccount.Balance >= this._amount)
            {
                this._withdraw.Execute();
                this._deposit.Execute();
                if (!_deposit.Success)
                {
                    this._withdraw.Rollback();
                }
                
            }
        }

        public void Rollback()
        {          
            if (this._reversed)
            {
                throw new OperationCanceledException("The transaction has already reversed.");
            }
            else if(this._fromAccount.Balance < this._amount)
            {
                throw new OperationCanceledException("Insufficient fund to reverse transaction.");
            }
            else if (!this.Sucess)
            {
                throw new OperationCanceledException("The transaction has not been complete.");
            }
            else if (this.Sucess)
            {
                this._withdraw.Rollback();
                this._deposit.Rollback();
                this._reversed = true;
            }
        }
    }
}
