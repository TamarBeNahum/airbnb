namespace airbnb.Models
{
    public class Order
    {
        int id; //מספר מזהה הזמנה
        int userId; //תעודת זהות מזמין
        int flatId; //מספר מזהה דירה
        DateTime startDate;
        DateTime endDate;
        static List<Order> orderList = new List<Order>();

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        static public List<Order> Read()
        {
            return orderList;
        }
        public bool Insert()
        {
            //check the flat exist 
            if (!Flat.ifFaltExist(this.FlatId))
            {
                return false;
            }
            //check the order is not already exist
            foreach (Order o in orderList)
            {
                if (o.Id == this.Id)
                {
                    return false;
                }
            }
            //(this.flatId) לא מושכרת באותם תאריכים שבהזמנה אחרת (o.flatId) בדיקה שהדירה שבהזמנה הנוכחית 
            foreach (Order o in orderList)
            {
                if (o.flatId == this.flatId)
                {
                    //אם התאריך התחלה או התאריך סיום בין לבין התאריכים בהם היא כבר בר מוזכרת
                    if (this.startDate >= o.startDate && this.startDate <= o.endDate ||
                        this.endDate >= o.startDate && this.endDate <= o.endDate)
                    {
                        return false;
                    }
                }
            }
            orderList.Add(this);
            return true;
        }
    }
}
