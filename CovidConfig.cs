using System;
using System.IO;
using Newtonsoft.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private const string fileName = "covid_config.json";

    public CovidConfig()
    {
        if (File.Exists(fileName))
        {
            string jsonData = File.ReadAllText(fileName);
            var config = JsonConvert.DeserializeObject<CovidConfig>(jsonData);
            this.satuan_suhu = config.satuan_suhu;
            this.batas_hari_deman = config.batas_hari_deman;
            this.pesan_ditolak = config.pesan_ditolak;
            this.pesan_diterima = config.pesan_diterima;
        }
        else
        {
            // default value
            this.satuan_suhu = "celcius";
            this.batas_hari_deman = 14;
            this.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            this.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
            SaveToFile();
        }
    }

    public void SaveToFile()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public void UbahSatuan()
    {
        if (satuan_suhu == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else
        {
            satuan_suhu = "celcius";
        }
        SaveToFile();
    }
}
