namespace ServiceBus.Producer.Requests {
    public class CreateCustomerRequest {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
