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
		/// проиошло событие - изменнеие свойства
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// произошло событие PropertyChanged
		/// </summary>
		/// <param name="name">имя изменившегося свойства</param>
		private void RaisePropertyChanged(string name)
		{
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

		private DateTime _DateTime;
		/// <summary>
		/// Дата операции
		/// </summary>
		public DateTime DateTime
		{
			get { return _DateTime; }
			set
			{
				if (value == _DateTime)
					return;
				_DateTime = value;
				RaisePropertyChanged(nameof(DateTime));
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

		private string _Comment;

		/// <summary>
		/// Коментарий к транзакции
		/// </summary>
		public string Comment
		{
			get { return _Comment; }
			set
			{
				if (value == _Comment)
					return;
				_Comment = value;
				RaisePropertyChanged(nameof(Comment));
			}
		}

		public enum KindAccount
		{
			Наличные,
			Безналичные
		}

		/// <summary>
		/// Место списания/зачисления транзакции
		/// </summary>
		public KindAccount Account { get; private set; }
	}
}
