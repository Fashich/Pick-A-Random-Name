using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pembagian_Untuk_Organisasi_1.C
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
            Console.WriteLine("masukkin jumlah pembagian kelompoknya disini bestie =>:");
            int jumlahkelompok = int.Parse(Console.ReadLine());
            Dictionary<int, string> namakelompok = new Dictionary<int, string>();
            for (int i = 1; i <= jumlahkelompok; i++)
            {
                Console.WriteLine($"masukkin nama untuk kelompok {i} =>:");
                string inputnamakelompok = Console.ReadLine();
                namakelompok[i] = inputnamakelompok;
            }
            Dictionary<string, List<string>> kelompok = new Dictionary<string, List<string>>();
            foreach (var judulkelompok in namakelompok.Values)
            {
                kelompok[judulkelompok] = new List<string>();
            }
            Random acak = new Random();
            int jumlahanggota = listnama.Count;
            for (int i = 0; i < jumlahkelompok && listnama.Count > 0; i++)
            {
                int posisinama = acak.Next(listnama.Count);
                string pilihannama = listnama[posisinama];
                listnama.RemoveAt(posisinama);
                kelompok[namakelompok[i + 1]].Add(pilihannama);
            }
            for (int i = 0; i < listnama.Count; i++)
            {
                int posisikelompok = i % jumlahkelompok + 1;
                kelompok[namakelompok[posisikelompok]].Add(listnama[i]);
            }
            Console.WriteLine("\nIni hasil pembagian kelompoknya!");
            foreach (var antrian in kelompok)
            {
                Console.WriteLine($"anggota kelompok {antrian.Key}: {string.Join(", ", antrian.Value)}");
            }
            while (true)
            {
                Console.WriteLine("\nApakah setiap kelompok ingin memiliki koor/kepala? (iya/tidak):");
                string pemilihankoor = Console.ReadLine().Trim().ToLower();
                if (pemilihankoor == "iya")
                {
                    foreach (var antrian in kelompok)
                    {
                        if (antrian.Value.Count > 0)
                        {
                            int posisipemilihankoor = acak.Next(antrian.Value.Count);
                            string koor = antrian.Value[posisipemilihankoor];
                            Console.WriteLine($"koor/kepala Divisi untuk kelompok {antrian.Key}: {koor}");
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
                    Console.WriteLine("Pembagian selesai, Follow IG: @thalassaaddict._.");
                    break;
                }
                else
                {
                    Console.WriteLine("masukkan dengan benar bestie. masukkan 'ya' atau 'tidak'.");
                }
            }
        }
    }
}