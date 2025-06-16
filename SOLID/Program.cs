IRepository<string> beerData = new BeerData();

beerData.Add("IPA");
beerData.Add("Stout");
beerData.Add("Lager");

var reportGeneratorBeer = new ReportGeneratorBeer(beerData);
var reportGeneratorHtmlBeer = new ReportGeneratorHtmlBeer(beerData);
var report = new Report();
report.Save(reportGeneratorHtmlBeer, "beer_report.html");

Show(reportGeneratorBeer);

void Show(IReportShow report) 
{
    report.Show();
}

public interface IRepository<T>
    {
    void Add(T item);
    List<T> Get();
}

public interface IReportGenerator
{
    public string Generate();
}

public interface IReportShow
{
    public void Show();
}

public class BeerData : IRepository<string>
{
    protected List<string> beers;

    public BeerData()
    {
        beers = new List<string>();
    }

    public virtual void Add(string beer) => beers.Add(beer);

    public List<string> Get() => beers;

}

public class LimitedBeerData
{
    private IRepository<string> beerData;
    private int limit;
    private int count = 0;

    public LimitedBeerData(int limit, IRepository<string> beerData)
    {
        this.limit = limit;
        this.beerData = beerData;
    }

    public void Add(string beer)
    {
        if (count >= limit)
        {
            throw new InvalidOperationException($"Cannot add more than {limit} beers.");
        }
        beerData.Add(beer);
        count++;
    }
}

public class  ReportGeneratorBeer : IReportGenerator, IReportShow
{
    private IRepository<string> beerData;
    public ReportGeneratorBeer(IRepository<string> beerData)
    {
        this.beerData = beerData;
    }

    public string Generate()
    {
        string data = "";
        foreach (var beer in beerData.Get())
        {
            data += $"Beer: {beer}\n";

        }
        return data;
    }

    public void Show()
    {
        Console.WriteLine(Generate());
    }
}
public class ReportGeneratorHtmlBeer : IReportGenerator
{
    private IRepository<string> beerData;
    public ReportGeneratorHtmlBeer(IRepository<string> beerData)
    {
        this.beerData = beerData;
    }
    public string Generate()
    {
        string data = "<html><body>";
        foreach (var beer in beerData.Get())
        {
            data += $"<p>Beer: {beer}</p>";
        }
        data += "</body></html>";
        return data;
    }
}
public class Report
{
    public void Save(IReportGenerator reportGenerator, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            string data = reportGenerator.Generate();
            writer.Write(data);
        }
    }
}