using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
     class Department:Employee
    {
      
      
        
        public void AddDepartment() // departman eklemek için kullandığım fonksiyon
        {
            
            Console.WriteLine("Enter the name of the department you want to add.");
        
            DepartmentList();

            using (System.IO.StreamWriter d = new System.IO.StreamWriter(@"C:\Users\Sena\Desktop\Departman.txt", true))
                d.WriteLine(Console.ReadLine());
            //count++;
            Console.WriteLine("Do you want to continue adding?(Y),press any key for main menu");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                AddDepartment();
            }
            else
            {
                MainMenu();//ana menü fonksiyonunu çağordım 
               
            }
           
        }


        public void DepartmentPerson()//departmana ait personelleri listelemek için tanımladığım fonksiyon
        {
            Console.WriteLine("Please select department");
            DepartmentList();
            string[] perList = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt", Encoding.GetEncoding("UTF-8"));// dosya okuma işlemleri
            string[] depart = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Departman.txt", Encoding.GetEncoding("UTF-8"));
            int choice = Convert.ToInt32(Console.ReadLine());
            foreach (string per in perList)//personel listesinin içinde dönüyor
            {
                if (per.Contains(depart[choice - 1]))//personel listesinin içinde seçtiğim departmana ait personel varsa ekrana yazdırmak için yazdığım komut
                {
                    Console.WriteLine(per);
                    
                }
               
                else
                {
                    
                    go:
                    Console.WriteLine("There is no personnel for the department you selected.press (E) for main menu");
                    if (Console.ReadLine().ToUpper()=='E'.ToString())
                    {
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice");
                        goto go;
                    }
                  
                }
            }



        }
        public void DeleteDepartment()//departman silmek için tanımladığım fonksiyon/metod
        {
            DepartmentList();
            Console.WriteLine("Please enter the department serial number you want to delete");
            int choice = Convert.ToInt32(Console.ReadLine());
         //   string[] satirlar = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Departman.txt", Encoding.GetEncoding("UTF-8"));
            List<string> depList = File.ReadAllLines(@"C:\Users\Sena\Desktop\Departman.txt").ToList();//departman dosyasını okuyarak depList adında bir liste atıyorum.
            for (int i = 0; i < depList.Count; i++)
            {
                if (choice == (i + 1))
                {
                    
                    Console.Write("Are you sure you want to delete(Y)/(N)");
                    char c = Convert.ToChar(Console.ReadLine().ToUpper());
                    if (c == 'Y')
                    {
                       
                        depList.RemoveAt(i);//depList listesinden removeAte metodunu kullanarak bulunduğu indexi siliyorum
                        File.WriteAllLines(@"C:\Users\Sena\Desktop\Departman.txt", depList.ToArray());//sildikten sonra dosyaya son halini yazdırıyorum
                        DepartmentList();
                        contin:
                        Console.WriteLine("press (E) to continue deleting,press (1) for main menu");
                        if (Console.ReadLine()=="1")
                        {
                            MainMenu();
                        }
                        else if (Console.ReadLine().ToUpper() == "E")
                        {
                            DeleteDepartment();
                        }
                        else
                        {
                            Console.WriteLine("Wrong choice try again");
                            goto contin;//eğer yanlış karakter girerse kullanıcı goto komutuyla kullanıcı devam etmesi gereken satıra gönderiyorum
                        }
                    }
                    
                    else if (c == 'N')
                    {
                        git:
                        Console.WriteLine("Press (Y) to view department list ,press (N) for main menu");
                        if (Console.ReadLine().ToUpper()=='Y'.ToString())
                        {
                            DepartmentList();
                        }
                        else if (Console.ReadLine().ToUpper() == 'N'.ToString())
                        {
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("Wrong choice try again");
                            goto git;
                        }
                    }

                }
            }
        }
        public void DepartmentList()//departmanların listeleneceği fonksiyon tanımı
        {


           
            string[] depList = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Departman.txt", Encoding.GetEncoding("UTF-8"));

            int count = 0;//departmanlara sıra numarası verebilmek için tanımladığım değişken
            foreach (string s in depList)
            {

                Console.WriteLine("{0} {1} ", count + 1, s);
                count++;
            }

        }
     
    }
}
