using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AbstractedTransaction
{
    public abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;
        private bool _executed;
        private bool _reversed;
        protected DateTime _dateStamp;

        public bool Success { get => this._success; }
        public bool Executed { get => this._executed; }
        public bool Reversed { get => this._reversed; }
        public DateTime DateStamp { get => this._dateStamp; }

        public virtual string Type { get; }

        public Transaction(decimal amount)
        {
            this._amount = amount;
            
        }

        public virtual void Print()
        {

        }

        public virtual void Execute()
        {

        }

        public virtual void Rollback()
        {

        }
    }
}
