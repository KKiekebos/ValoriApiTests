namespace ValoriApiTests.Models
{
    internal class ShowInfo
    {
        public required Show Show { get; set; }
    }

    internal class Show
    {
        public int Id { get; set; }

        public required string Url { get; set; }
    }
}
