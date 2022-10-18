using DenominationCalculatorAPI.Model;
using System.Collections.Generic;
using System.Text;

namespace DenominationCalculatorAPI.IService
{
    public interface IDenominationCalculatorService
    {
        public IEnumerable<int> GetAllDenominations();

        public StringBuilder CalculateDenominations(InputCurrency inputCurrency);
    }
}