using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PaymentSystem
{
    public class LichSuGiaoDich
    {
        private const string FilePath = "LichSuGiaoDich.json";
        private List<string> giaoDichs = new List<string>();

        public void ThemGiaoDich(string giaoDich)
        {
            giaoDichs.Add(giaoDich);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(giaoDichs, Formatting.Indented));
        }

        public void XemLichSu()
        {
            if (File.Exists(FilePath))
            {
                string content = File.ReadAllText(FilePath);
                List<string> lichSu = JsonConvert.DeserializeObject<List<string>>(content);

                Console.WriteLine("Lịch sử giao dịch:");
                foreach (var item in lichSu)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Không có lịch sử giao dịch.");
            }
        }
    }
}
