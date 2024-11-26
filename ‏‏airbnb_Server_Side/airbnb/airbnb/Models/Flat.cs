namespace airbnb.Models
{
    public class Flat
    {
        int id;
        string city;
        string address;
        int numOfRooms;
        double price;
        string imgUrl;
        string apartmentName;
        float reviewScore;
        string description;


        static List<Flat> flatslist = new List<Flat>();

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public int NumOfRooms { get => numOfRooms; set => numOfRooms = value; }
        public double Price
        {
            get => price;
            set
            {
                if (numOfRooms > 1 && value > 100)
                {
                    value *= 0.9;
                }
                price = value;
            }
        }
        public string ImgUrl { get => imgUrl; set => imgUrl = value; }
        public string ApartmentName { get => apartmentName; set => apartmentName = value; }
        public float ReviewScore { get => reviewScore; set => reviewScore = value; }
        public string Description { get => description; set => description = value; }

        static public List<Flat> Read()
        {
            return flatslist;
        }

        //Adding an apartment - only if it doesn't already exist
        public bool Insert()
        {
            foreach (Flat f in flatslist)
            {
                if (f.id == this.id)
                {
                    return false;
                }
            }
            flatslist.Add(this);
            return true;
        }

        //Auxiliary method - if an apartment is in the apartment array
        static public bool ifFaltExist(int flatId)
        {
            foreach (Flat f in flatslist)
            {
                if (f.id == flatId)
                {
                    return true;
                }
            }
            return false;
        }

        /////////////// EX_2 ///////////////////

        //return all flats whose price is *cheaper* then the flat diven (by id)
        static public List<Flat> GetByPrice(double price)
        {
            List<Flat> flats = new List<Flat>();
            foreach (Flat f in flatslist)
            {
                if (f.price < price)
                {
                    flats.Add(f);
                }
            }
            return flats;
        }

        //return all the apartments located in a certain city that are rated above or equal to a parameter rating
        static public List<Flat> GetByCityRating(string city, float reviewScore)
        {
            List<Flat> flats = new List<Flat>();
            foreach (Flat f in flatslist)
            {
                if (f.City == city && (f.reviewScore > reviewScore || f.reviewScore == reviewScore))
                {
                    flats.Add(f);
                }
            }
            return flats;
        }

        //delete the given apartment from the “data base” (static list)
        static public bool DeleteById(int id)
        {
            foreach (Flat f in flatslist)
            {
                if (f.id == id)
                {
                    flatslist.Remove(f);
                    return true;
                }
            }
            throw new Exception("There is no apartment with such an ID number that can be deleted");
        }
    }
}
