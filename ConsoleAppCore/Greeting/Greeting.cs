using System;

namespace Greetings
{
    public static class Greeting
    {
        public static string Greet(string username)
        {
            return $"{DateTime.Now:HH:mm:ss} Hello, {username.Trim()}!";
        }
    }
}
