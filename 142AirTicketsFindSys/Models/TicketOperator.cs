using System.Text.Json;
using System.Windows.Forms;

public class TicketOperator
{
    private List<Flyway> _flyWays;
    public List<Flyway> flyWays { get { return _flyWays; } }
    public string startCity;
    public TicketOperator(string city)
    {
        this._flyWays = new List<Flyway>();
        startCity = city;
    }
    public void addRoute(int id, string[] route,int places,DateTime startTime,DateTime endTime)
    {

        
        _flyWays.Add(new Flyway(id, route, places, startTime, endTime));
        //...
    }
    public void delRoute(int id)
    {
        _flyWays.RemoveAt(id);
    }
    public List<string[]> getSortetPrettyRoutes(string destination)
    {
        List<string[]> ways = new List<string[]>();
        for(int i = 0; i < _flyWays.Count; i++)
        {
            if(Array.IndexOf(_flyWays[i].route,destination) ==-1) continue;
            ways.Add(_flyWays[i].getPrettyWay());
            

        }

        return ways;
    }
    public List<Flyway> getSortetRoutes(string destination)
    {
        List<Flyway> ways = new List<Flyway>();
        for (int i = 0; i < _flyWays.Count; i++)
        {
            if (Array.IndexOf(_flyWays[i].route, destination) == -1) continue;
            ways.Add(_flyWays[i]);


        }

        return ways;
    }
    public bool buyTicket(int id,int amount)
    {
        if(flyWays[id].places>=amount && amount > 0)
        {
            flyWays[id].buyTickets(amount);
            return true;
        }
        return false;
    }
    
    public void save(string path)
    {
        string[][][] json = new string[_flyWays.Count][][];
        int i = 0;
        foreach (Flyway el in _flyWays)
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
        _flyWays.Clear();
        foreach (var el in file)
        {
            _flyWays.Add(new Flyway(el));
        }

    }

}