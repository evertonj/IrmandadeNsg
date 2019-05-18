namespace IrmandadeNsg.Application.EventSourcedNormalizers
{
    public class PostHistoryData
    {
        public string Action { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Created { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string MainComments { get; set; } = string.Empty;
        public string When { get; set; } = string.Empty;
        public string Who { get; set; } = string.Empty;
    }
}