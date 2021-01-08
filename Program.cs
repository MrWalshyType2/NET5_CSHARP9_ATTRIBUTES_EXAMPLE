using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcomer.Welcome(GetAuthorNameFromAnnotation(typeof(Welcomer)));
            Welcomer.Welcome("Fred");
        }

        static string GetAuthorNameFromAnnotation(Type t)
        {
            AuthorAttribute AuthorAttribute = 
                (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));

            if (AuthorAttribute == null)
            {
                Console.WriteLine("Annotation not found.");
                return "";
            }
            else
            {
                return AuthorAttribute.Name;
            }
        }
    }

    [Author("Morgan W", version = 1.0)]
    internal static class Welcomer
    {
        // Morgan, 1.0
        public static void Welcome(string name = "Morgan")
        {
            Console.WriteLine($"Welcome {name}");
        }
    }
}
