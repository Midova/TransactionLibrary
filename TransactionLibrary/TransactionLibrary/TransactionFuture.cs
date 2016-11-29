using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
	public class TransactionFuture : Transaction
	{
		public TransactionFuture()
		{
			// NOTE: нужен для сериализации.
		}

		// NOTE: пока не ясно что тут
		public TransactionFuture(double amount, string category) : base(amount, category)
		{
		}
	}
}
