# Panteon.HistoryStorage
Panteon.HistoryStorage

![](https://github.com/PanteonProject/panteon-dashboard/blob/master/misc/path4141.png)  


**Simple History Storage interface**
```cs
public interface IHistoryStorage
{
  bool Store(HistoryModel historyModel);
  IEnumerable<HistoryModel> Load(string name, DateTime? from = null, DateTime? to = null);
}

public class HistoryModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Details { get; set; }
  public DateTime DateCreated { get; set; }
}
``` 

## License
Code and documentation are available according to the *MIT* License (see [LICENSE](https://raw.githubusercontent.com/PanteonProject/Panteon.HistoryStorage/master/LICENSE)).
