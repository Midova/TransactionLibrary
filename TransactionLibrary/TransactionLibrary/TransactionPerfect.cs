using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	class TransactionPerfect : Transaction
	{
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
