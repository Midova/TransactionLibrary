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

		public double GetBalance
		{
			get
			{
				double balance = 0D;
				foreach (TransactionPerfect transaction in PerfectTransaction)
				{
					balance = balance + transaction.Amount;
				}
				return balance;
			}
		}

		public IEnumerable<TransactionPerfect> GetTransactionPeriod(DateTime startDate, DateTime endDate)
		{
			List<TransactionPerfect> whileIncome = new List<TransactionPerfect>();
			foreach (TransactionPerfect item in PerfectTransaction)
			{
				if (item.DateTime >= startDate & item.DateTime <= endDate)
				{
					whileIncome.Add(item);
				}
				if (whileIncome.Count == 0)
				{
					Console.WriteLine("Операций в заданый период не совершалось");
				}
			}
			return whileIncome;

		}

		public double GetIncomePeriod(DateTime startDate, DateTime endDate)
		{

		}

		public double GetCostPeriod(DateTime startDate, DateTime endDate)
		{

		}

		
	}
}
