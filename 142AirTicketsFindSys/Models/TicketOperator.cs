using System.Text.Json;
using System.Windows.Forms;

class TicketOperator
{
    public List<Flyway> flyWays;
    public TicketOperator()
    {
        flyWays = new List<Flyway>();
    }
    public void addRoute(int id, string[] route,int places,DateTime startTime,DateTime endTime)
    {

        
        flyWays.Add(new Flyway(id, route, places, startTime, endTime));
        //...
    }
    public string[][] getPrettyRoutes()
    {
        string[][] ways = new string[flyWays.Count][];
        for(int i = 0; i < flyWays.Count; i++)
        {
            ways[i] = flyWays[i].getPrettyWay();

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