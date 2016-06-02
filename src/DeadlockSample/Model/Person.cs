namespace DeadlockSample.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address AddressOne { get; set; }
        public Address AddressTwo { get; set; }
    }
}
