namespace FocusFlow.DB
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string? Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsDone { get; set; }


    }
}
