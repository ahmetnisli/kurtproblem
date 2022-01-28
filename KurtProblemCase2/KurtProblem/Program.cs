using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // Console.WriteLine("Dizi boyutunu giriniz.");
            string arrayCountStr = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(arrayCountStr))
            {
                Console.WriteLine("Lütfen Dizi boyutu giriniz.");
                return;
            }
            int arrayCount = 0;
            int.TryParse(arrayCountStr, out arrayCount);
            if(arrayCount == 0)
            {
                Console.WriteLine("Lütfen dizi boyutunu sayı olarak giriniz.");
                return;
            }
            if(arrayCount < 5 || arrayCount > 200000)
            {
                Console.WriteLine("Dizi boyutu 5 ile 200000 arasında olmalıdır.");
                return;
            }
           // Console.WriteLine("Diziyi giriniz");
            var array = Console.ReadLine();
            Regex rgx2 = new Regex("\t|\\s+");
            string arrayResult = rgx2.Replace(array.Trim(), "");

            IEnumerable<Int32> valueList = ArrayInputControlAndGetValueList(arrayResult, arrayCount);
            if (valueList == null)
            {
                return;
            }
            List<ValueClass> values = valueList.GroupBy(x => x).Select(x => new ValueClass { Id = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).ThenBy(x => x.Id).ToList();
            Console.WriteLine(values[0].Id);
            Console.ReadKey();
            
        }

        private class ValueClass
        {
            public int Id { get; set; }
            public int Count { get; set; }
        }

        private static List<Int32> ArrayInputControlAndGetValueList(string result, int arrayCount)
        {
            try
            {

               List<Int32> valueList = result.Select(c => c - '0').ToList();
               if(valueList.Count != arrayCount)
                {
                    Console.WriteLine("Girdiğiniz dizi boyutu ile eleman sayısı aynı olmalıdır.");
                    return null;
                }
                if(valueList.Any(x=> x < 1 || x > 5))
                {
                    Console.WriteLine("Girilen değerler 1 ile 5 arasında olmalıdır.");
                    return null;
                }
               return valueList;
            }
            catch (Exception)
            { 
                Console.WriteLine("Giriş dizisi hatalıdır.");
            }
            return null;
        }
    }
}
