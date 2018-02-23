using System;
using System.Collections.Generic;
using System.IO;

namespace ATM
{
    //Francesca and Julia wrote this class
    public class Account
    {
        public string name;
        public static int id = 0;
        public int pin;
        public decimal balance;

        public Account(string n, int p)
        {
            name = n;
            pin = p;
            balance = 0;
            id++;
        }

        public Account(string n, int p, decimal b, int i)
        {
            name = n;
            pin = p;
            balance = b;
            id = i;
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

        public int get_id()
        {
            return id;
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
            string account_string = $"{name}\t{pin.ToString()}\t{id.ToString()}\t{balance.ToString()}";
            return account_string;
        }
    }

    //Francesca and Julia wrote this class
    public class Bank
    {
        Dictionary<int,Account> accounts = new Dictionary<int,Account>();

        public void add_account(Account acc)
        {
            accounts[acc.get_id()] = acc;
        }

        public Account get_account_by_id(int x)
        {
            return accounts[x];
        }

        public void update_file()
        {
            StreamWriter sw = new StreamWriter("BankRecords.txt",false);
            foreach(KeyValuePair<int,Account> entry in accounts)
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
                while (line[i] != "\t") {}
                string name = line[0:i];
                i++;
                j = i;
                while (line[i] != "\t") {}
                int pin = Convert.ToInt32(line[j: i]);
                i++;
                j = i;
                while (line[i] != "\t") {}
                int id = Convert.ToInt32(line[j: i]);
                i++;
                j = i;
                while (line[i] != "\t") {}
                decimal balance = Convert.ToDecimal(line[j: i]);

                Account new_account = Account(name, pin, balance, id);
                accounts[new_account.get_id()] = new_account;
            }
        }
    }

}
