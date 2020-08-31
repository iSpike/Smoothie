using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FruitySmoothie.Classes
{
    public class Smoothie
    {
		static Dictionary<string, string> prices = new Dictionary<string, string>()
		{
			{ "Strawberries", "£1.50" },
			{ "Banana", "£0.50" },
			{ "Mango", "£2.50" },
			{ "Blueberries", "£1.00" },
			{ "Raspberries", "£1.00" },
			{ "Apple", "£1.75" },
			{ "Pineapple", "£3.50" }
		};

		public Smoothie(string[] ingredients)
		{
			this.Ingredients = ingredients;
		}

		public string[] Ingredients { get; private set; }

		public string GetCost()
		{
			if (!this.Ingredients.Any())
			{
				return string.Empty;
			}

			return string.Format("£{0}", decimal.Round(this.GetCostDecimal(), 2));
		}

		public string GetPrice()
		{
			if (!this.Ingredients.Any())
			{
				return string.Empty;
			}

			var cost = this.GetCostDecimal();
			return string.Format("£{0}", decimal.Round(cost + (cost * 1.5M), 2));
		}

		public string GetName()
		{
			if (!this.Ingredients.Any())
			{
				return string.Empty;
			}

			var ingredients = this.Ingredients.Select(i => { return i.Contains("berries") ? i.Replace("berries", "berry") : i; }).OrderBy(i => i).ToList();
			if (ingredients.Count() == 1)
			{
				return string.Format("{0} {1}", ingredients[0], "Smoothie");
			}
			else
			{
				return string.Format("{0} {1}", string.Join(" ", ingredients), "Fusion");
			}

		}

		private decimal GetCostDecimal()
		{
			return this.Ingredients.Sum(i => prices.ContainsKey(i) ? decimal.Parse(prices[i].Replace("£", string.Empty)) : 0);
		}
	}
}
