using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	class TransactionPerfect : Transaction
	{

		/// <summary>
		/// Конструктор с 2-я параметрами.
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		public TransactionPerfect(double amount, string category)
		{
			Amount = amount;
			Category = category;
			DateTime = DateTime.Now;
			Comment = "";
			KindAccount = AccountType.Наличные;
		}

		/// <summary>
		/// Конструктор с 3-я параметрами.
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		/// <param name="dateTime">дата транзакции</param>
		public TransactionPerfect(double amount, string category, DateTime dateTime)
		{
			Amount = amount;
			Category = category;
			DateTime = dateTime;
			Comment = "";
			KindAccount = AccountType.Наличные;
		}

		/// <summary>
		/// Конструктор с 4-ю параметрами.
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		/// <param name="dateTime">дата транзакции</param>
		/// <param name="comment">коментарий к транзакции</param>
		public TransactionPerfect(double amount, string category, DateTime dateTime, string comment)
		{
			Amount = amount;
			Category = category;
			DateTime = dateTime;
			Comment = comment;
			KindAccount = AccountType.Наличные;
		}

		/// <summary>
		/// Конструктор с 5-ю параметрами.
		/// </summary>
		/// <param name="amount">сумма транзакции</param>
		/// <param name="category">категория транзакции</param>
		/// <param name="dateTime">дата транзакции</param>
		/// <param name="comment">коментарий к транзакции</param>
		/// <param name="kindAccount">тип счета транзакции</param>
		public TransactionPerfect(double amount, string category, DateTime dateTime, string comment, AccountType kindAccount)
		{
			Amount = amount;
			Category = category;
			DateTime = dateTime;
			Comment = comment;
			KindAccount = kindAccount;
		}

		private DateTime _DateTime;
 		/// <summary>
 		/// Дата операции.
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

		private string _Comment;

		/// <summary>
		/// Коментарий к транзакции.
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

		public enum AccountType
		{
			Наличные, 
			Безналичные
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
	}
}
