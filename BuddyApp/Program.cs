using System;
using System.Collections.Generic;
using System.Linq;

namespace BuddyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new[]
            {
                "Mary",
                "John",
                "Peter",
                "Ann",
                "Barbara"
            };

            var usersBuddyTemp = users.ToList();

            var rand = new Random();

            var result = new Dictionary<string, string>();

            var userBuddy = string.Empty;
            var userKey = string.Empty;

            for (int i = 0; i < users.Length; i++)
            {
                if (i == 0)
                {
                    userBuddy = usersBuddyTemp[rand.Next(usersBuddyTemp.Count)];
                    usersBuddyTemp.Remove(userBuddy);

                    userKey = usersBuddyTemp[rand.Next(usersBuddyTemp.Count)];
                    usersBuddyTemp.Remove(userKey);

                    result[userKey] = userBuddy;
                    userKey = userBuddy;

                    continue;
                }

                if (usersBuddyTemp.Count == 0)
                {
                    result[userKey] = result.First().Key;
                    break;
                }

                userBuddy = usersBuddyTemp[rand.Next(usersBuddyTemp.Count)];
                result[userKey] = userBuddy;

                userKey = userBuddy;
                usersBuddyTemp.Remove(userBuddy);

            }

            Console.WriteLine("----- Users -----");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();

            Console.WriteLine("----- Buddy Users -----");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
