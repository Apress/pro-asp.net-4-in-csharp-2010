
public class MyObjectDataSource {

    public class DataItem {
        public string Name {get; set;}
        public double Popularity {get; set;}
    }

    public DataItem[] GetData() {
        return new DataItem[] {
            new DataItem() {Name = "Cheesecake", Popularity = 30},
            new DataItem() {Name = "Ice Cream", Popularity = 30},
            new DataItem() {Name = "Fudge", Popularity = 20},
            new DataItem() {Name = "Milkshake", Popularity = 20}
        };
    }
}