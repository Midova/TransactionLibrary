using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary
{
    class TransactionTemplate : Transaction
    {
		/// <summary>
		/// Фабрика. Создаем TransactionPerfect с параметрами текущей TransactionTemplate
		/// </summary>
		/// <returns></returns>
		public TransactionPerfect CreateOperation()
		{
			var TemplateChange = new TransactionPerfect(Amount, Category);
			return TemplateChange;
		}

	}
}
