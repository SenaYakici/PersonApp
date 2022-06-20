using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
          go:
            Console.WriteLine("User Name:");
            string user = Console.ReadLine();
            Console.WriteLine("Password:");
            string pas = PasswordHide();
            Menu m = new Menu();
            Employee emp = new Employee();
            

            if (user == "admin" && pas == "1234")
            {
         
                m.MainMenu(); //eğer kullanıcı adı ve şifre doğru ise ana menüye kullanıcıyı yönlendirdim.

           }
            else
            {
                Console.WriteLine("Username or password is incorrect, try again");
                goto go;//kullanıcı adı veya şifre hatalı ise goto kullanarak yukarıya gönderdim kullanıcıdan tekrar bilgi alması için.
            }

            Console.ReadKey();
        }
        private static string PasswordHide()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);//kullanıcının klavyeden bastığı tuşu bulabilmek için key isimli consoleKeyinfo nesnesi tanımladım.
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)//eğer tuş backspace ve enter tuşu değilse 
                {
                    pass += key.KeyChar; //tuşu değerini pass değişkeninde atıyorum
                    Console.Write("*");//yıldız koyarak şifreyi gölgeliyorum 
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)// eğer backspace tuşuna basılmışsa ve şifrenin uzunluğu 0 dan büyükse şifreyi silebilmek için yazdığım koşul ifadesi
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)//eğer enter tuşuna basılmışsa döngüü kırabilmek için yazılmış koşul
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
    }
}
