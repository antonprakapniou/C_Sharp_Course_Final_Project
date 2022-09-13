namespace Validation
{    
    public class Pattern:IDisposable

    {
        public string[]? Name { get; set; }
        public string[]? Password { get; set; }
        public string[]? Email { get; set; }

        public Pattern()
        {
            Name = new string[2] { @"^[a-z]+\s?[a-z]+$", "The name must contain both letters and a maximum of one space. Try again" };
            Password = new string[2] { @"^([0-9a-z]|\W){6}$", "Password must contain at least 6 characters. Try again" };
            Email = new string[2] { @"^\S+@\S+.\S+$", "Invalid email value. Try again" };
        }

        public void Dispose() { }
    }
}