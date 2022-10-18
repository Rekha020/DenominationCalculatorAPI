using DenominationCalculatorAPI.IService;
using DenominationCalculatorAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DenominationCalculatorAPI.Service
{
    public class DenominationCalculatorService : IDenominationCalculatorService
    {
        private enum denominations
        {

            EUR50 = 50,
            EUR20 = 20,
            EUR10 = 10,
            EUR5 = 5,
            EUR2 = 2,
            EUR1 = 1,
        }


        public IEnumerable<int> GetAllDenominations()
        {
            int[] values = (int[])Enum.GetValues(typeof(denominations));
            var sortedNumbers = values.OrderByDescending(x => x).ToList();
            return sortedNumbers;

        }

        public StringBuilder CalculateDenominations(InputCurrency inputCurrency)
        {
            decimal amount = inputCurrency.Amount;
            decimal pricevalue =inputCurrency.Price;
            StringBuilder result = new StringBuilder();
            if (amount < pricevalue)
            {
                result.Append("The amount is less than price of product\nPlease provide amount more than price of product");
            }
            else if (amount == pricevalue)
            {
                result.Append("Your Change is 0");
            }
            else
            {
                int temp = 0;
                decimal returnAmount = amount - pricevalue;
                string[] differenceValues = returnAmount.ToString().Split('.');
                int difference = Convert.ToInt32(differenceValues[0]);
                int[] values = (int[])Enum.GetValues(typeof(denominations));
                var sortedNumbers = values.OrderByDescending(x => x).ToArray();
                result.Append("Your Change is");
                result.Append("\n");
                foreach (int item in sortedNumbers)
                {
                    temp = (int)difference / item;
                    difference = difference % item;
                    if (temp >= 1)
                    {
                        result.Append(temp + "*" + Enum.GetName(typeof(denominations), item));
                        result.Append("\n");
                    }
                    if (difference == 0)
                    {
                        break;
                    }

                }
                if (differenceValues.Length > 1)
                {
                    result.Append(1 + "*" + Convert.ToInt32(differenceValues[1])*10 + "P");
                }

            }
            return result;
        }

    }
}