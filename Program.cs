using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine("== APLIKASI CEK KONDISI MASUK GEDUNG ==\n");

        // opsional: ubah satuan jika mau
        config.UbahSatuan();
        Console.WriteLine("Satuan suhu sekarang: " + config.satuan_suhu);

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuNormal = (suhu >= 36.5 && suhu <= 37.5);
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal = (suhu >= 97.7 && suhu <= 99.5);
        }

        bool sehat = suhuNormal && (hariDemam < config.batas_hari_deman);

        Console.WriteLine(sehat ? config.pesan_diterima : config.pesan_ditolak);
    }
}
