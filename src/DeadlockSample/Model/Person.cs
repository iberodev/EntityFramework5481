namespace DeadlockSample.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressOneId { get; set; }
        public Address AddressOne { get; set; }
        public int? AddressTwoId { get; set; }
        public Address AddressTwo { get; set; }
    }
}
