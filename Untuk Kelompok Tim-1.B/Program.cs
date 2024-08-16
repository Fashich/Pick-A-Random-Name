using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untuk_Kelompok_Tim_1.B
{
    internal class Program
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
            while (true)
            {
                Console.WriteLine("\nApakah setiap kelompok ingin memiliki ketua tim/kelompok? (iya/tidak):");
                string pemilihankoor = Console.ReadLine().Trim().ToLower();
                if (pemilihankoor == "iya")
                {
                    foreach (var antrian in kelompok)
                    {
                        if (antrian.Value.Count > 0)
                        {
                            int posisipemilihankoor = acak.Next(antrian.Value.Count);
                            string koor = antrian.Value[posisipemilihankoor];
                            Console.WriteLine($"ketua tim untuk kelompok {antrian.Key}: {koor}");
                        }
                        else
                        {
                            Console.WriteLine($"kelompok {antrian.Key} tidak memiliki anggota.");
                        }
                    }
                    break;
                }
                else if (pemilihankoor == "tidak")
                {
                    Console.WriteLine("pembagian selesai, Follow IG: @thalassaaddict._.");
                    break;
                }
                else
                {
                    Console.WriteLine("masukkan dengan benar bestie. masukkan 'iya' atau 'tidak'.");
                }
            }
        }
    }
}