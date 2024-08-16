using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spin_Wheel_Version_1.D
{
    class Program
    {
        static void Main()
        {
            List<string> listnama = new List<string>();
            List<string> urutankepilih = new List<string>();
            Console.WriteLine("list namanya disini bestie & pisahkan dengan koma juga =>");
            string inputan = Console.ReadLine();
            string[] masukkannama = inputan.Split(',');
            foreach (var nama in masukkannama)
            {
                listnama.Add(nama.Trim());
            }
            if (listnama.Count == 0)
            {
                Console.WriteLine("oops! sesuatu yang membuat bestie lupa memasukkan list namanya, coba lagi bestie!");
                return;
            }
            Random acak = new Random();
            bool lanjut = true;
            while (lanjut)
            {
                if (listnama.Count == 0)
                {
                    Console.WriteLine("maaf bestie kayaknya namanya udah kepilih semua & gaada yang tersisa lagi:(");
                    break;
                }
                int posisinama = acak.Next(listnama.Count);
                string pilihannama = listnama[posisinama];
                listnama.RemoveAt(posisinama);
                urutankepilih.Add(pilihannama);
                Console.WriteLine($"\nnama yang kedapet adalah => {pilihannama}");
                if (listnama.Count > 0)
                {
                    Console.WriteLine("\nlist data yang belum kepilih:");
                    foreach (var nama in listnama)
                    {
                        Console.WriteLine(nama);
                    }
                }
                Console.WriteLine("\nbestie mau spin ulang atau lanjut? kalo mau ngulang ketik 'spin ulang' & kalo mau lanjut ketik 'lanjutkan' ");
                string pilihan = Console.ReadLine().ToLower();
                if (pilihan == "spin ulang")
                {
                    listnama.Add(pilihannama);
                }
                else if (pilihan == "lanjutkan spin")
                {
                    if (listnama.Count == 1)
                    {
                        urutankepilih.Add(listnama[0]);
                        listnama.Clear();
                    }
                    if (listnama.Count == 0)
                    {
                        Console.WriteLine("maaf bestie kayaknya namanya udah kepilih semua & gaada yang tersisa lagi:(");
                        lanjut = false;
                    }
                }
                else
                {
                    Console.WriteLine("sepertinya ada kesalahan, maaf bestie selamat tinggal:<");
                    lanjut = false;
                }
            }
            if (urutankepilih.Count > 0)
            {
                Console.WriteLine("\nini dia hasil akhirnya bestie =>");
                for (int i = 0; i < urutankepilih.Count; i++)
                {
                    Console.WriteLine($"yang kepilih ke-{i + 1} adalah => {urutankepilih[i]}");
                }
            }
        }
    }
}
