using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    //Francesca and Julia wrote this class
    public class Account
    {
        public int accNum;
        private string name;
        private int pin;
        private decimal balance;

        public Account(int AccountNumber, string n, int p)
        {
            accNum = AccountNumber;
            name = n;
            pin = p;
            balance = 0;
        }

        public Account(int AccountNumber, string n, int p, decimal b)
        {
            accNum = AccountNumber;
            name = n;
            pin = p;
            balance = b;
        }

        public void deposit(decimal amount)
        {
            balance += amount;
        }

        public Boolean withdraw(decimal amount)
        {
            if ((balance - amount) < 0)
            {
                return false;
            }
            else
            {
                balance = balance - amount;
                return true;
            }
        }

        public decimal get_balance()
        {
            return balance;
        }

        public string get_name()
        {
            return name;
        }

        public int get_acc_num()
        {
            return accNum;
        }
        
        public Boolean verify_pin(int inputted_pin)
        {
            if (inputted_pin == pin)
                return true;
            else
                return false;
        }

        public string toString()
        {
            string account_string = $"{accNum.ToString()}\t{name}\t{pin.ToString()}\t{balance.ToString()}";
            return account_string;
        }
    }

    //Francesca and Julia wrote this class
    public class Bank
    {
        Dictionary<int, Account> accounts = new Dictionary<int, Account>();

        public Bank()
        {
            Account tester = new Account(1, "John Snow", 1234);
            decimal x = 500.2m;
            tester.deposit(x);
            add_account(tester);
        }

        public void add_account(Account acc)
        {
            accounts[acc.accNum] = acc;
        }

        public Account get_account_by_number(int AccountNumber)
        {
            try
            {
                return accounts[AccountNumber];
            }
            catch
            {
                return null;
            }
        }
       
        public void update_file()
        {
            StreamWriter sw = new StreamWriter("BankRecords.txt", false);
            foreach (KeyValuePair<int, Account> entry in accounts)
            {
                sw.WriteLine(entry.Value.toString());
            }
            sw.Close();
        }

        public void restore_file()
        {
            StreamReader sr = new StreamReader("BankRecords.txt");
            string[] lines = System.IO.File.ReadAllLines("BankRecords.txt");
            foreach (string line in lines)
            {
                int i = 0;
                int j = 0;
                while (String.Equals(line[i].ToString(), "\t", StringComparison.Ordinal) { }
                int acc_num = Convert.ToInt32(line.Substring(0, i));
                i++;
                j = i;
                while (String.Equals(line[i].ToString(), "\t", StringComparison.Ordinal) { }
                string name = line.Substring(j, i);
                i++;
                j = i;
                while (String.Equals(line[i].ToString(), "\t", StringComparison.Ordinal) { }
                int pin = Convert.ToInt32(line.Substring(j, i));
                i++;
                j = i;
                while (String.Equals(line[i].ToString(), "\t", StringComparison.Ordinal) { }
                decimal balance = Convert.ToDecimal(line.Substring(j, i));

                Account new_account = new Account(acc_num, name, pin, balance);
                accounts[new_account.get_acc_num()] = new_account;
            }
        }
    }

