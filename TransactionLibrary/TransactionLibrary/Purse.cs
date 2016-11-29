using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	public class Purse
	{		
		public Purse()
		{
			NamePursr = string.Empty;
			MadeTransaction = new ObservableCollection<TransactionMade>();
			TemplateTransaction = new ObservableCollection<TransactionTemplate>();
			FutureTransaction = new ObservableCollection<TransactionFuture>();
		}
		
		public Purse (string namePurse) : this()
		{
			NamePursr = namePurse;			
		}
		
		/// <summary>
		/// название кошелька
		/// </summary>
		public string NamePursr { get; set; }

		/// <summary>
		/// Список совершенных операций
		/// </summary>
		public ObservableCollection<TransactionMade> MadeTransaction { get; set; }

		/// <summary>
		/// Список шаблонов транзакций
		/// </summary>
		public ObservableCollection<TransactionTemplate> TemplateTransaction { get; set; }

		/// <summary>
		/// список планируемых операций
		/// </summary>
		public ObservableCollection<TransactionFuture> FutureTransaction { get; set; }

		/// <summary>
		/// получает баланс кошелька
		/// </summary>
		public double GetBalance
		{
			get
			{
				double balance = 0D;

				foreach (TransactionMade transaction in MadeTransaction)				
					balance += transaction.Amount;
								
				return balance;
			}
		}

		/// <summary>
		/// Метод: возвращает список транзакций за заданый период
		/// </summary>
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <returns>список транзакций за заданый период</returns>
		public IEnumerable<TransactionMade> GetTransactionPeriod(DateTime startDate, DateTime endDate)
		{
			var matches = MadeTransaction.Where(item => item.DateTime >= startDate && item.DateTime <= endDate);

			return new List<TransactionMade>(matches);
		}

		/// <summary>
		/// Метод: возвращает список транзакций за заданный период на заданнои счете
		/// </summary>		
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <param name="accountType">тип счета</param>
		/// <returns>список транзакий</returns>
		public IEnumerable<TransactionMade> GetTransactionPeriod(DateTime startDate, DateTime endDate, AccountType accountType)
		{
			List<TransactionMade> whileTransaction = new List<TransactionMade>();
			whileTransaction = (List<TransactionMade>)GetTransactionPeriod(startDate, endDate);

			foreach (TransactionMade item in MadeTransaction)
			{
				if (item.KindAccount == accountType)
					whileTransaction.Add(item);
			}
						
			return whileTransaction;
		}

		/// <summary>
		/// Метод: возварщает сумму прихода/расхода за заданный период
		/// </summary>
		/// <param name="debit">тип операции</param>		
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <returns>cумма прихода/расхода</returns>
		public double GetIncomeCostPeriod(Debit debit, DateTime startDate, DateTime endDate)
		{
			List<TransactionMade> transactionIncomeCost = new List<TransactionMade>();
			transactionIncomeCost = (List<TransactionMade>)GetTransactionPeriod(startDate, endDate);
			
			var sum = transactionIncomeCost.Where(item => item.IsDebit == debit).Sum(item => item.Amount);			

			return sum;
		}

		/// <summary>
		/// Метод: возварщает сумму прихода/расхода за заданный период на заданном счете
		/// </summary>
		/// <param name="debit">тип операции</param>
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <param name="accountType">тип счета</param>
		/// <returns>сумма прихода/расхода</returns>
		public double GetIncomeCostPeriod(Debit debit, DateTime startDate, DateTime endDate, AccountType accountType)
		{
			List<TransactionMade> transactionIncomeCost = new List<TransactionMade>();
			transactionIncomeCost = (List<TransactionMade>)GetTransactionPeriod(startDate, endDate, accountType);
			double sum = 0D;

			foreach (TransactionMade item in transactionIncomeCost)			
				if (item.IsDebit == debit)
					sum = sum + item.Amount;		

			return sum;
		}

		
	}
}
