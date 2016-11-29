using Catel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	public abstract class Transaction : ObservableObject
	{ 
		/// <summary>
		/// Метод инициализации транзакции с параметрами.
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		public Transaction(double amount, string category)
		{
			Amount = amount;
			Category = category;
		}

		public Transaction()
		{
			Amount = 0;
			Category = string.Empty;
		}

		private double _Amount;

		/// <summary>
		/// Задает или возвпащает Сумма транзакции.
		/// </summary>
		public double Amount
		{
			get { return _Amount; }
			set
			{
				if (value == _Amount)
					return;

				_Amount = value;
				RaisePropertyChanged(nameof(Amount));
				RaisePropertyChanged(nameof(IsDebit));
			}
		}

		private string _Category;

		/// <summary>
		/// категория транзакции.
		/// </summary>
		public string Category
		{
			get { return _Category; }
			set
			{
				if (value == _Category)
					return;
				_Category = value;
				RaisePropertyChanged(nameof(Category));
			}
		}

		/// <summary>
		/// Передает приход или расход.
		/// </summary>
		public Debit IsDebit
		{
			get
			{
				if (_Amount >= 0)
					return Debit.Parish;

				return Debit.Spending;
			}
		}		
	}
}
