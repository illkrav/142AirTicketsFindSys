using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

public class TicketOperator
{
    //private List<Flyway> _flyWays;
    public List<Flyway> FlyWays { get; private set; }
    //public string StartCity;
    private string[] RandCityAr;
    public TicketOperator()
    {
        this.FlyWays = new List<Flyway>();
        //this.StartCity = city;
        this.RandCityAr = ["Анкара","Абу-Даби","Осака","Нью-Дели","Стамбул","Тель-Авів"];
    }
    public void AddRoute(int id, string[] route,int[] places,DateTime startTime,DateTime endTime)
    {

        
        FlyWays.Add(new Flyway(id, route, places, startTime, endTime));
        //...
    }
    public void DelRoute(int id)
    {
        FlyWays.RemoveAt(id);
    }
    public void ClearWays()
    {
        FlyWays.Clear();
    }
    public List<Flyway> GetSortetRoutes(string destination)
    {
        List<Flyway> ways = new List<Flyway>();
        for (int i = 0; i < FlyWays.Count; i++)
        {
            if (Array.IndexOf(FlyWays[i].Route, destination) == -1) continue;
            if (FlyWays[i].Places[0] + FlyWays[i].Places[1] == 0 || FlyWays[i].EndTime < DateTime.Now) continue;
            ways.Add(FlyWays[i]);


        }
        ways = ways.OrderBy(x => x.StartTime).ToList();
        return ways;
    }
    public bool BuyTicket(int id,int amount,int clas)
    {
        if (FlyWays[id].Places[clas] >=amount && amount > 0)
        {
            FlyWays[id].Places[clas]-=amount;
            return true;
        }
        return false;
    }
    
    public void Save(string path)
    {
        //string[][][] json = new string[FlyWays.Count][][];
        //int i = 0;
        //var jsonEx2;
        //foreach (Flyway el in FlyWays)
        //{
            //json[i] = el.saveData();
             
            //i++;

        //}
        var jsonEx2 = JsonSerializer.Serialize(FlyWays,new JsonSerializerOptions { WriteIndented = true });
        
        //string jsonEx = JsonSerializer.Serialize(json);
        File.WriteAllText(path + ".json", jsonEx2);

    }
    public void Load(string path)
    {
        if(!File.Exists(path + ".json"))return;
        string text = File.ReadAllText(path + ".json");
        
        FlyWays = JsonSerializer.Deserialize<List<Flyway>>(text);
        
        //FlyWays.Clear();
        //foreach (var el in file)
        //{
        //    FlyWays.Add(new Flyway(el));
        //}

    }
    public void GenRandData()
    {

        int lastId = FlyWays.Count>0 ?FlyWays.Last().Id:14;
        for(int i = 0; i < 20; i++)
        {
            DateTime startdt = DateTime.Now.AddHours(new Random().Next(72));
            FlyWays.Add(new Flyway(100+lastId + i, [RandCityAr[i%RandCityAr.Length], RandCityAr[(i+1) % RandCityAr.Length]],[30- new Random().Next(30), 90 - new Random().Next(90)], startdt,startdt.AddHours(new Random().Next(12)+1)));
        }
        for (int i = 0; i < 20; i++)
        {
            DateTime startdt = DateTime.Now.AddHours(new Random().Next(72));
            FlyWays.Add(new Flyway(200+lastId + i, [RandCityAr[i % RandCityAr.Length], RandCityAr[(i + 1) % RandCityAr.Length], RandCityAr[(i + 3) % RandCityAr.Length]], [30 - new Random().Next(30), 90 - new Random().Next(90)], startdt, startdt.AddHours(new Random().Next(12)+1)));
        }
    }

}