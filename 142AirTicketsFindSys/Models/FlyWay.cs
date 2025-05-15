class Flyway
{
    public int id;
    public string[] route;
    public int places;
    public DateTime startTime;
    public DateTime endTime;
    public Flyway(int id, string[] route, int places,DateTime startTime,DateTime endTime)
    {
        this.id = id;
        this.route = route;
        this.places = places;
        this.startTime = startTime;
        this.endTime = endTime;
    }
    public string[] getPrettyWay()
    {
        string middle = "";
        for(int i = 1; i < route.Length - 1; i++)
        {
            middle += route[i] + "-";
        }
        middle = middle.Remove(middle.Length - 1,1);
        return [id.ToString(), route[0] + "-" + route.Last(),middle,places.ToString(),startTime.ToString(),(endTime-startTime).ToString()];
    }
    
}