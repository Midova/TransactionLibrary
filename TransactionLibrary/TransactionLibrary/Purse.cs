using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	class Purse
	{
		
		public Purse()
		{
			NamePursr = "";
			PerfectTransaction = new ObservableCollection<TransactionPerfect>();
			TemplateTransaction = new ObservableCollection<TransactionTemplate>();
			FutureTransaction = new ObservableCollection<TransactionFuture>();
		}
		
		public Purse (string namePurse)
		{
			NamePursr = namePurse;
			PerfectTransaction = new ObservableCollection<TransactionPerfect>();
			TemplateTransaction = new ObservableCollection<TransactionTemplate>();
			FutureTransaction = new ObservableCollection<TransactionFuture>();
		}
		
		/// <summary>
		/// название кошелька
		/// </summary>
		public string NamePursr { get; private set; }

		/// <summary>
		/// Список совершенных операций
		/// </summary>
		public ObservableCollection<TransactionPerfect> PerfectTransaction { get; set; }

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

				foreach (TransactionPerfect transaction in PerfectTransaction)				
					balance = balance + transaction.Amount;
								
				return balance;
			}
		}

		/// <summary>
		/// Метод: возвращает список транзакций за заданый период
		/// </summary>
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <returns>список транзакций за заданый период</returns>
		public IEnumerable<TransactionPerfect> GetTransactionPeriod(DateTime startDate, DateTime endDate)
		{
			List<TransactionPerfect> whileTransaction = new List<TransactionPerfect>();
			foreach (TransactionPerfect item in PerfectTransaction)
			{
				if (item.DateTime >= startDate && item.DateTime <= endDate)
					whileTransaction.Add(item);
			}
				
			if (whileTransaction.Count == 0)				
				Console.WriteLine("Операций в заданый период не совершалось");				
			
			return whileTransaction;
		}

		/// <summary>
		/// Метод: возвращает список транзакций за заданный период на заданнои счете
		/// </summary>		
		/// <param name="startDate">начало периода</param>
		/// <param name="endDate">конец периода</param>
		/// <param name="accountType">тип счета</param>
		/// <returns>список транзакий</returns>
		public IEnumerable<TransactionPerfect> GetTransactionPeriod(DateTime startDate, DateTime endDate, AccountType accountType)
		{
			List<TransactionPerfect> whileTransaction = new List<TransactionPerfect>();
			whileTransaction = (List<TransactionPerfect>)GetTransactionPeriod(startDate, endDate);

			foreach (TransactionPerfect item in PerfectTransaction)
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
			List<TransactionPerfect> transactionIncomeCost = new List<TransactionPerfect>();
			transactionIncomeCost = (List<TransactionPerfect>)GetTransactionPeriod(startDate, endDate);
			double sum = 0D;			

			foreach (TransactionPerfect item in transactionIncomeCost)			
				if (item.IsDebit==debit)				
					sum = sum + item.Amount;

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
			List<TransactionPerfect> transactionIncomeCost = new List<TransactionPerfect>();
			transactionIncomeCost = (List<TransactionPerfect>)GetTransactionPeriod(startDate, endDate, accountType);
			double sum = 0D;

			foreach (TransactionPerfect item in transactionIncomeCost)			
				if (item.IsDebit == debit)
					sum = sum + item.Amount;		

			return sum;
		}
	}
}
