using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
   public class TransactionTemplate : Transaction, IEditableObject
    {
		public TransactionTemplate()
		{
			// NOTE: Поддержка сериализации, т.к. без этого конструктора не работает сериализация.
		}

		public TransactionTemplate(double amount, string category, AccountType kindAccount) : base(amount, category)
		{
			KindAccount = kindAccount;
		}

		private AccountType _KindAccount;

		/// <summary>
		/// Место проведения транзакции.
		/// </summary>
		public AccountType KindAccount
		{
			get { return _KindAccount; }
			set
			{
				if (value == _KindAccount)
					return;

				_KindAccount = value;
				RaisePropertyChanged(nameof(KindAccount));
			}
		}

		/// <summary>
		/// Фабрика. Создаем TransactionPerfect с параметрами текущей TransactionTemplate
		/// </summary>
		/// <returns></returns>
		public TransactionMade CreateOperation()
		{
			return new TransactionMade(Amount, Category, KindAccount);
		}

		private Transaction _OldTransaction;

		public void BeginEdit()
		{
			_OldTransaction = new TransactionMade(this.Amount, this.Category);
		}

		public void EndEdit()
		{
		}

		public void CancelEdit()
		{
			this.Amount = _OldTransaction.Amount;
			this.Category = _OldTransaction.Category;
		}
	}
}
