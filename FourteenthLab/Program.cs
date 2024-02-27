using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FourteenthLab
{
    class TradingCompany
    {
        public string Name { get; set; }
        public string ProductSpecification { get; set; }
        public string Address { get; set; }

        public TradingCompany(string name, string productSpec, string address)
        {
            Name = name;
            ProductSpecification = productSpec;
            Address = address;
        }
    }

    class Program
    {
        static void Main()
        {
            List<TradingCompany> companies = new();

            static void initCompaniesList(List<TradingCompany> companies)
            {
                using StreamReader sr = new("companies.txt");
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    TradingCompany company = new(parts[0], parts[1], parts[2]);
                    companies.Add(company);
                }
            }
            initCompaniesList(companies);

            static void filterCompanies(List<TradingCompany> companies)
            {
                var clothingAndShoecompanies = companies.Where(
                    f =>
                        f.ProductSpecification == "магазин одежды"
                        || f.ProductSpecification == "обувной"
                );

                Console.WriteLine("\nОтфильтрованные фирмы:");
                foreach (var company in clothingAndShoecompanies)
                {
                    Console.WriteLine(
                        $"{company.Name} - {company.ProductSpecification} - {company.Address}"
                    );
                }
            }
            filterCompanies(companies);

            static void proectionCompanies(List<TradingCompany> companies)
            {
                var shoeStores = companies
                    .Where(f => f.ProductSpecification == "обувной")
                    .Select(f => new { Name = f.Name, Address = f.Address });

                Console.WriteLine("\nОбувные магазины:");
                foreach (var store in shoeStores)
                {
                    Console.WriteLine($"{store.Name} - {store.Address}");
                }
            }
            proectionCompanies(companies);

            static void sortCompanies(List<TradingCompany> companies)
            {
                // Сортировка
                var sortedcompanies = companies.OrderBy(f => f.Address).ThenBy(f => f.Name);

                Console.WriteLine("\nОтсортированные фирмы:");
                foreach (var company in sortedcompanies)
                {
                    Console.WriteLine(
                        $"{company.Name} - {company.ProductSpecification} - {company.Address}"
                    );
                }
            }
            sortCompanies(companies);

            static void groupCompanies(List<TradingCompany> companies)
            {
                var groupedCompanies = companies.GroupBy(f => f.ProductSpecification);

                Console.WriteLine("\nСгруппированные фирмы:");
                foreach (var group in groupedCompanies)
                {
                    Console.WriteLine(group.Key);
                    foreach (var company in group)
                    {
                        Console.WriteLine($"  {company.Name} - {company.Address}");
                    }
                }
            }
            groupCompanies(companies);

            static void groupWithCountCompanies(List<TradingCompany> companies)
            {
                var groupedCompanies = companies
                    .GroupBy(f => f.ProductSpecification)
                    .Select(
                        g =>
                            new
                            {
                                ProductSpecification = g.Key,
                                Count = g.Count(),
                                Companies = g.ToList()
                            }
                    );

                Console.WriteLine(
                    "\nСгруппированные фирмы с подсчетом количества элементов в каждой группе:"
                );

                foreach (var group in groupedCompanies)
                {
                    Console.WriteLine(
                        $"{group.ProductSpecification} - Количества элементов: {group.Count}"
                    );
                    foreach (var company in group.Companies)
                    {
                        Console.WriteLine($"  {company.Name} - {company.Address}");
                    }
                }
            }
            groupWithCountCompanies(companies);

            static void countProductCompanies(List<TradingCompany> companies)
            {
                int count = companies.Count(c => c.ProductSpecification == "продуктовый");

                Console.WriteLine(
                    "\nЧисло торговых фирм продающих продукты питания: " + count.ToString()
                );
            }
            countProductCompanies(companies);

            static void extractClothingAndShoeShops(List<TradingCompany> companies)
            {
                IEnumerable<TradingCompany> clothingAndShoecompanies = companies
                    .SkipWhile(
                        c =>
                            c.ProductSpecification != "магазин одежды"
                            && c.ProductSpecification != "обувной"
                    )
                    .TakeWhile(
                        c =>
                            c.ProductSpecification == "магазин одежды"
                            || c.ProductSpecification == "обувной"
                    );

                Console.WriteLine("\nФирмы:");
                foreach (var company in clothingAndShoecompanies)
                {
                    Console.WriteLine(
                        $"{company.Name} - {company.ProductSpecification} - {company.Address}"
                    );
                }
            }
            extractClothingAndShoeShops(companies);

            static void hasJewelryShops(List<TradingCompany> companies)
            {
                Console.WriteLine(
                    "\nИмеются ли торговые фирмы продающие ювелирные изделия: "
                        + companies.Any(с => с.ProductSpecification == "Ювелирный")
                );
            }
            hasJewelryShops(companies);

            static void mergeCompanies(
                List<TradingCompany> companies,
                List<TradingCompany> companies2
            )
            {
                Console.WriteLine("\nОбъединение двух последовательностей:");
                foreach (var company in companies.Union(companies2))
                {
                    Console.WriteLine(
                        $"{company.Name} - {company.ProductSpecification} - {company.Address}"
                    );
                }
            }
            List<TradingCompany> companies2 = new();
            initCompaniesList(companies2);
            mergeCompanies(companies, companies2);
        }
    }
}
