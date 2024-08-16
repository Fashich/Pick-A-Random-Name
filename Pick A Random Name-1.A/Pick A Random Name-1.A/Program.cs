using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pick_A_Random_Name_1.A
{
    class Program
    {
        static void Main()
        {
            List<string> listnama = new List<string>();
            Console.WriteLine("masukkin namanya disini bestie =>:");
            string inputan = Console.ReadLine();
            string[] masukkannama = inputan.Split(',');
            foreach (var nama in masukkannama)
            {
                listnama.Add(nama.Trim());
            }
            Console.WriteLine("masukkin pembagian kelompoknya disini =>:");
            int jumlahkelompok = int.Parse(Console.ReadLine());
            Dictionary<int, List<string>> kelompok = new Dictionary<int, List<string>>();
            for (int i = 1; i <= jumlahkelompok; i++)
            {
                kelompok[i] = new List<string>();
            }
            Random acak = new Random();
            int jumlahanggota = listnama.Count;
            for (int i = 0; i < jumlahkelompok && listnama.Count > 0; i++)
            {
                int posisinama = acak.Next(listnama.Count);
                string pilihannama = listnama[posisinama];
                listnama.RemoveAt(posisinama);
                kelompok[i + 1].Add(pilihannama);
            }
            for (int i = 0; i < listnama.Count; i++)
            {
                int posisikelompok = i % jumlahkelompok + 1;
                kelompok[posisikelompok].Add(listnama[i]);
            }
            Console.WriteLine("\nini hasil pembagian kelompoknya!");
            for (int i = 1; i <= jumlahkelompok; i++)
            {
                Console.WriteLine($"anggota kelompok {i}: {string.Join(", ", kelompok[i])}");
            }
        }
    }
}