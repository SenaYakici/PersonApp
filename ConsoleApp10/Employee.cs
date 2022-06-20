using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApp10
{
    class Employee : Menu // menu sınıfından emplyee diye bir alt sınıf türeterek menu sınıfının özelliklerini türettiğim sınıftada kullanbiliyorum
    {

        ArrayList tarihb = new ArrayList();
        string name, surname;

        long telNo;


        public void LeaveDate()//Personellere izin tarihlerini girmek için kullandığım fonksiyon
        {


            string[] perList = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt", Encoding.GetEncoding("UTF-8"));
            string permitStart;//izin başlangıç tarihini tutacağım permitStart adında bir değişken tanımladım
            string permitFinish;//izin bitiş tarihi
            DateTime todayDate = DateTime.Now;//todayDate isminde bugünün tarihini tutacağı bir değişken tanımladım
            if (perList.Length != 0)//personel listesinin boş-dolu kontrolü
            {
                ListPerson();

                Console.WriteLine("Please select the personnel for whom you will enter the leave date");

                int ch = Convert.ToInt32(Console.ReadLine());

                using (System.IO.StreamWriter d = new System.IO.StreamWriter(@"C:\Users\Sena\Desktop\izinTarih.txt", true))//dosyaya yazmak için streamWriter sınıfı kullandım

                    if (perList[ch - 1] != null)
                    {
                        Console.Write("Please enter the permit start date dd.mm.yyyy");
                        permitStart = Console.ReadLine();
                        Console.Write("Please enter the permission finish date dd.mm.yyyy");
                        permitFinish = Console.ReadLine();

                        DateTime sDate = DateTime.Parse(permitStart);
                        DateTime fDate = DateTime.Parse(permitFinish);
                        d.WriteLine(perList[ch - 1] + "    " + sDate + " - " + fDate);
                        d.Close();
                        Console.WriteLine("To continue adding permission dates (Y)/(N) ,to list personnel whose leave is approaching (L) harfine basınız.");
                        char choice = Convert.ToChar(Console.ReadLine().ToUpper());
                        TimeSpan t = sDate - todayDate;
                        if (t.Days < 10)
                        {
                            // Console.WriteLine(izin[i]);
                            tarihb.Add(perList[ch - 1] + sDate + fDate);

                        }

                        // sw.WriteLine(satirlar[sec - 1] + "    " + tarih + " - " + tarih2);
                        if (choice == 'Y')
                        {
                            LeaveDate();
                        }
                        else if (choice == 'N')
                        {
                            MainMenu();
                        }
                        else if (choice == 'L')
                        {
                            string[] izin = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\izinTarih.txt", Encoding.GetEncoding("UTF-8"));

                            for (int i = 0; i <= izin.Length; i++)
                            {
                                foreach (var a in tarihb)
                                {
                                    Console.WriteLine(a);
                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("You entered the wrong character, please make the selections again..");
                        }


                    }

            }


        }


        public void AddPerson() //personel eklemek için oluşturduğum fonksiyon
        {
            Department dep = new Department(); // departman sınıfına ait özellikleri kullanabilmek için sınıfa ait nesne oluşturdum

            FileStream fs = new FileStream("C:\\Users\\Sena\\Desktop\\Kisiler.txt", FileMode.Append, FileAccess.Write, FileShare.Write); //Personel listesinin verileri text dosyasına yazmak için filestream sınıfı kullandım .dosya konumu belirttim 
            StreamWriter sw = new StreamWriter(fs); //verileri dosyaya yazmak için streamWriter nesnesi oluşturdum
            Console.Write("Name :");// kullanıcıya gerekli bilgileri sorabilmek için console.Write komutunu kullandım.

            name = Console.ReadLine(); //kullanıcın girdiği veriyi okumak için kulllandığım komut
                                       //  kullaniciAd.Add(ad);

            sw.Write(name); //oluşturduğum nesneyi kullanarak write metoduyla dosyaya yazdım

            Console.Write("Surname :");
            // kullanici.Add(soyad);
            surname = Console.ReadLine();
            //  soyadi.Add(soyad);
            sw.Write("\t\t" + surname + " ");
            //  Console.Write("Departman seçiniz:\n 1)Bilişim \n 2)Finans \n 3)Pazarlama ");
            Console.WriteLine("Select department ");
            string[] departmentText = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Departman.txt", Encoding.GetEncoding("UTF-8"));// dosyayı satır satır okumak için file readAllLines fonksiyonunu kullanarak okuduğum dosyayı bir dizi içerisine attım.
            //  int i = 0;
            if (departmentText.Length != 0)//departman dosyasının boş olup olmama durumu kontrol ettim
            {
                dep.DepartmentList();//departman listesini görüntülemek için departmanList metodunu çağırdım.yukarıda departman sınıfından nesne türetmiştim.
                int choice = Convert.ToInt32(Console.ReadLine());

                sw.Write("\t\t" + departmentText[choice - 1]);

            }
            else
            {
                Console.WriteLine("Please add department");
                dep.AddDepartment();
            }

            Console.Write("Phone Number : ");
            telNo = Convert.ToInt64(Console.ReadLine());
            //tel.Add(telNo);
            sw.WriteLine("\t " + telNo);
            Console.WriteLine("Adding staff completed.");
            sw.Close();//nesneyi kapatıyorum
            MainMenu();
        }
        public void DeletePerson()//personel silmek için oluşturduğum fonksiyon
        {
            ListPerson();//kayıtlı personelleri görebilmek için oluşturduğum listPerson metodunu çağırdım.
            Console.WriteLine("Please enter the sequence number of the person you want to delete.");
            // string[] perList = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt", Encoding.GetEncoding("UTF-8"));
            List<string> perlist = File.ReadAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt").ToList(); //personellerin bulunduğu dosyayı okuyarak bir list içine attım

            int choice = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < perlist.Count; i++)//perlis listesinin içinde döndüm.
            {
                if (choice == (i + 1))
                {
                    Console.Write("Are you sure you want to delete(Y)/(N)");
                    char s = Convert.ToChar(Console.ReadLine().ToUpper());// toupper fonksiyonu kullanıcı konsolda küçük bir karaktere bastığında karakteri büyütmek için kullandım.
                    if (s == 'Y')
                    {

                        perlist.RemoveAt(i);//removeAt fonksiyonu ile belirtilen index teki elemanı silmek için kullandım
                        File.WriteAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt", perlist.ToArray());//satır silindikten sonra dosyaya listenin son halini yazdırdım.
                        ListPerson();
                        Console.WriteLine("to continue deleting (Y) to exit the process (N) press character");
                        char c = Convert.ToChar(Console.ReadLine().ToUpper());
                        if (c == 'Y')
                        {
                            DeletePerson();
                        }
                        else if (c == 'N')
                        {
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("you entered wrong character");
                            MainMenu();

                        }
                    }
                    else if (s == 'N')
                    {
                        MainMenu();
                    }

                }
            }

        }
        public void ListPerson()//kayıtlı personelleri listelemek için listPerson adında bir fonksiyon oluşturdum.
        {
            Console.WriteLine("Sequence No|  Personnel Name  | Personnel Surname |  Departman Name  | Phone No  ");
            string[] perList = System.IO.File.ReadAllLines(@"C:\Users\Sena\Desktop\Kisiler.txt", Encoding.GetEncoding("UTF-8"));
            int counter = 0;
            foreach (string s in perList)
            {

                Console.WriteLine((counter + 1) + ")\t \t " + s);
                counter++;
            }
           

        }
    }
}
