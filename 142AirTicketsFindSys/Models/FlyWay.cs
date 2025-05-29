public class Flyway
{
    public int Id { get; set; }
    public string[] Route { get; set; }
    public int[] Places { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Flyway(int id, string[] route, int[] places,DateTime startTime,DateTime endTime)
    {
        this.Id = id;
        this.Route = route;
        this.Places = places;
        this.StartTime = startTime;
        this.EndTime = endTime;
    }
    
    public Flyway()
    {

    }
    public string[] GetPrettyWay()
    {
        string middle = "";
        for(int i = 0; i < Route.Length - 1; i++)
        {
            middle += Route[i] + "---";
        }
        middle = middle.Remove(middle.Length - 3,3);
        return [Id.ToString(), Route.Last(), middle, Places[0].ToString()+"|"+ Places[1].ToString(), StartTime.ToString(),((int)((EndTime-StartTime).TotalHours)).ToString()+"h"];
    }
    public void BuyTickets(int amount,int clas)
    {
        Places[clas] -= amount;
    }
    

}