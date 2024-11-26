namespace airbnb.Models
{
    public class User
    {
        string id; //צריך להיות יוניק
        string name;
        string country;
        string email;
        string password;
        string phoneNumber;

        static List<User> users = new List<User>();
        public string Id { get => id; set => id = value; }
        public string Country { get => country; set => country = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Name { get => name; set => name = value; }

        static public List<User> Read()
        {
            return users;
        }

        //Adding an user - only if it doesn't already exist (by email)
        public bool Insert()
        {
            foreach (User u in users)
            {
                if (u.id == this.id)
                {
                    return false;
                }
            }
            users.Add(this);
            return true;
        }

        //for log in - insernt user by email and password
        static public User PostByEmailPass(string email, string pass)
        {
            foreach (User u in users)
            {
                if (u.email == email && u.password == pass)
                {
                    return u;
                }
            }
            //If no user with that email and password combination is found
            throw new Exception("There is no user that mach the details given");
        }

    }
}
