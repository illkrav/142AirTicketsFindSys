using System.Text.Json;
using System.Windows.Forms;

public class TicketOperator
{
    public List<Flyway> flyWays;
    public string startCity;
    public TicketOperator(string city)
    {
        this.flyWays = new List<Flyway>();
        startCity = city;
    }
    public void addRoute(int id, string[] route,int places,DateTime startTime,DateTime endTime)
    {

        
        flyWays.Add(new Flyway(id, route, places, startTime, endTime));
        //...
    }
    public void delRoute(int id)
    {
        flyWays.RemoveAt(id);
    }
    public List<string[]> getSortetPrettyRoutes(string destination)
    {
        List<string[]> ways = new List<string[]>();
        for(int i = 0; i < flyWays.Count; i++)
        {
            if(Array.IndexOf(flyWays[i].route,destination) ==-1) continue;
            ways.Add(flyWays[i].getPrettyWay());
            

        }

        return ways;
    }
    
    public void save(string path)
    {
        string[][][] json = new string[flyWays.Count][][];
        int i = 0;
        foreach (Flyway el in flyWays)
        {
            json[i] = el.saveData();
            i++;

        }
        string jsonEx = JsonSerializer.Serialize(json);
        File.WriteAllText(path + ".json", jsonEx);

    }
    public void load(string path)
    {
        if(!File.Exists(path + ".json"))return;
        string text = File.ReadAllText(path + ".json");
        var file = JsonSerializer.Deserialize<string[][][]>(text);
        flyWays.Clear();
        foreach (var el in file)
        {
            flyWays.Add(new Flyway(el));
        }

    }

}