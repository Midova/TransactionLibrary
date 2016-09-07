using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	class Transaction : INotifyPropertyChanged
	{

		/// <summary>
		/// Метод инициализации транзакции с параметрами
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		public void Initialize(double amount, string category)
		{
			Amount = amount;
			Category = category;
		}		

		/// <summary>
		/// проиошло событие - изменнеие свойства
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// произошло событие PropertyChanged
		/// </summary>
		/// <param name="name">имя изменившегося свойства</param>
		protected void RaisePropertyChanged(string name)
		{
			//обработчик
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}

		private double _Amount;
		/// <summary>
		/// Сумма транзакции
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
		/// категория расхода/прихода
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

		public enum Debit
		{
			Приход,
			Расход
		}

		/// <summary>
		/// Передает приход или расход
		/// </summary>
		public Debit IsDebit
		{
			get
			{
				if (_Amount >= 0)
					return Debit.Приход;
				return Debit.Расход;
			}
		}
	}

		
}
