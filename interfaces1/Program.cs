using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using interfaces1.Entities;
using interfaces1.Services;

namespace interfaces1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter the number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            //generating contract
            Contract myContract = new Contract(number, date, value);

            //processing contract            
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, installments);
            Console.WriteLine();
            Console.WriteLine("Installments:");
            foreach(Installment i in myContract.Installments)
            {
                Console.WriteLine(i);
            }
            


        }
    }
}
