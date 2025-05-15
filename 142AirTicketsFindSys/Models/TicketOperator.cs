class TicketOperator
{
    public List<Flyway> flyWays;
    public TicketOperator()
    {

    }
    public void addRoute(Flyway way)
    {
        
        flyWays.Add(way);
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

}